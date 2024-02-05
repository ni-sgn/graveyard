package main

import (
	"context"
	"fmt"
	"log"
	"net/http"
)

func main() {
	ctx, cncl := context.WithTimeout(context.Background(), 3)
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

}
