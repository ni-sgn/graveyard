package main

import (
	"fmt"
	"log"
	"net/http"

	_ "golang.org/x/oauth2"
)

func ComposeMiddleware(next http.Handler) http.Handler {
	// http.HandlerFunc(...) is a type conversion
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		log.Println(("This is a log"))
		next.ServeHTTP(w, r)
	})

}

func CreateHandler(http.ResponseWriter, *http.Request) {
	fmt.Print("Handling")
}

func main() {
	// http.HandlerFunc(CreateHandler) is a type conversion
	http.Handle("/", ComposeMiddleware(http.HandlerFunc(CreateHandler)))

	slice := [3]int{1, 2}
	fmt.Printf("%d cap\n", cap(slice))
	http.ListenAndServe(":8080", nil)
}
