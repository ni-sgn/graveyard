package main

import (
	"context"
	"fmt"
	"log"
	"net/http"
	"time"

	"github.com/rs/cors"
)

func Index(rw http.ResponseWriter, r *http.Request) {
	ctx, cancel := context.WithTimeout(context.Background(), 10*time.Second)
	defer cancel()

	rwc := r.WithContext(ctx)

	// Set headers for SSE
	rw.Header().Set("Content-Type", "text/event-stream")
	rw.Header().Set("Cache-Control", "no-cache")
	rw.Header().Set("Connection", "keep-alive")

	f, ok := (rw).(http.Flusher)
	if !ok {
		log.Fatal("Can't convert")
	}
	i := -1

	for {
		select {
		case <-rwc.Context().Done():
			break
		default:
			i += 1
			// write data inside rw's buffer
			fmt.Fprintf(rw, "times: %d\n", i)
			// sends the data that is currently in the buffer
			// to the client
			f.Flush()
			time.Sleep(1 * time.Second)
		}
	}
}

func ErrTest(a int, b int) (int, error) {
	// computers have status registers?
	// during division, divisor is checked and pushed into
	// and either exception is thrown, or
	// hence exceptions can be interpreted differently
	// in different programming languges, as they are
	// hardware level information
	// in go, if b is 0, panic occures, which is
	// basically an exception
	return a / b, nil
}

func main() {

	val, err := ErrTest(3, 4)
	if err != nil {
		log.Fatalln(err)
	}
	fmt.Println(val)

	c := cors.New(cors.Options{
		AllowedOrigins:   []string{"*"}, // AllowedOrigins can be set to a list of origins or "*" to allow all origins
		AllowedMethods:   []string{"GET", "POST", "PUT", "DELETE", "OPTIONS"},
		AllowedHeaders:   []string{"*"}, // AllowedHeaders can be set to a list of headers or "*" to allow all headers
		AllowCredentials: true,
	})

	http.Handle("/", http.FileServer(http.Dir("static")))
	http.Handle("/events", c.Handler(http.HandlerFunc(Index)))
	err = http.ListenAndServe(":7000", nil)
	log.Fatalln(err)
}
