package main

import (
	"fmt"
	"log"
	"net/http"
)

var MiddleWareStack []func(http.Handler) http.Handler

func LogMW(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		fmt.Printf("This is pre logging")
		next.ServeHTTP(w, r)
	})
}

func add(funcs ...func(http.Handler) http.Handler) {
	MiddleWareStack = append(MiddleWareStack, funcs...)
}

func chain(middlewares []func(http.Handler) http.Handler, handler http.Handler) http.Handler {

	for i := len(middlewares) - 1; i >= 0; i-- {
		handler = middlewares[i](handler)
	}

	return handler
}

func handler(w http.ResponseWriter, r *http.Request) {
	fmt.Println("This is a handler")
}

func main() {
	add(LogMW)
	finalHandler := chain(MiddleWareStack, http.HandlerFunc(handler))
	conv, ok := finalHandler.(http.HandlerFunc)
	if !ok {
		log.Fatalln("Cant convert http.Handler to http.HandlerFunc")
	}
	http.HandleFunc("/", conv)

	fmt.Println("Starting server")
	http.ListenAndServe(":7000", nil)

}
