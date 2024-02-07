package main

import (
	"fmt"
	"log"
	"net/http"
)

func InitServer() {

	mux := http.NewServeMux()
	mux.HandleFunc("/create", CreateHandler)

	err := http.ListenAndServe("localhost:8080", mux)
	if err != nil {
		log.Fatal(err)
	}

}

func CreateHandler(rw http.ResponseWriter, req *http.Request) {
	a, ok := req.Context().Value("service").(Service)
	switch req.Method {
	case "GET":
		fmt.Fprintf(rw, "create")
	}
}
