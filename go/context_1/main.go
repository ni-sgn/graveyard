package main

import (
	"context"
	"fmt"
	"log"
	"net/http"
	"time"
)

type Atom struct {
	Id   int
	Head string
	Body string
	DT   time.Time
}

func IDoStuff(ctx context.Context) {
	// During http hanling, I can inject struct instances
	// into context, they will have request scope.
	// then read like this.
	val, ok := ctx.Value("atm").(Atom)
	if !ok {
		panic("Something went wrong")
	}

	fmt.Println("Dependency injeciton: ", val)
	select {
	// Probably starts a timer and returns a channel
	// timer is running non-blocking, when time runs out
	// sends signal to the channel (empty struct).
	// function returns channel, hence the possibility to use in select.
	// if function returns the channel it should be possible to case it.
	// this is the await pattern: function returns unbuffered channel,
	// where it will send the finish signal.
	case <-time.After(20 * time.Second):
		fmt.Printf("task completed successfully")
	}
}

func main() {
	ctx, cncl := context.WithTimeout(context.Background(), 1)
	defer cncl()
	if ctx == nil {
		log.Fatal("Should not be nil.")
	}

	req, err := http.NewRequestWithContext(ctx, "GET", "https://www.google.com", nil)
	if err != nil {
		log.Fatal("Should not be nil.")
	}

	// it supposed to be nil
	// and it is
	fmt.Println(req.Body)
	client := http.DefaultClient

	client.Do(req)

	ctx2, cncl2 := context.WithTimeout(context.Background(), 10*time.Second)
	ctx3 := context.WithValue(ctx2, "atm", Atom{Id: 1, Head: "hello", Body: "hello world", DT: time.Now()})
	defer cncl2()
	go IDoStuff(ctx3)

	select {
	// context.Done() function also returns a readonly channel
	// it should have a same functionality as time.After(...)
	// when set time runs out, it should send a finish signal
	case <-ctx3.Done():
		fmt.Println("Timed out")
		// I should be careful with default here. If all the channels
		// are empty, default will be automatically called.
		// Hence insead of default, I should use timer or context,
		// as a last case.
	}

}
