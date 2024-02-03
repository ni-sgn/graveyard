package main

import (
	"context"
	"encoding/json"
	"fmt"
	"io"
	"net/http"
)

// ** Retrieve data asynchronously ** //

// For some weird reason, I need to make names uppercase
// for unmarshalling or decoding
// I guess because it needs to be visible from other packages
type Res struct {
	One string `json:"one"`
	Key string `json:"key"`
}

func fetch(ctx context.Context) error {
	resp, err := http.Get("http://echo.jsontest.com/key/value/one/two")
	if err != nil {
		return err
	}
	// respo body might be just a query(unactualized data)
	defer resp.Body.Close()
	body := json.NewDecoder(resp.Body)
	for {
		var m Res = Res{}
		if err := body.Decode(&m); err == io.EOF {
			break
		} else if err != nil {
			panic("Error decoding")
		}
		fmt.Printf("%s: %s\n", m.Key, m.One)
	}

	return nil

}

func main() {
	//ctx, _ := context.WithTimeout(context.Background(), 5*time.Second)
	//_ = ctx

	fetch(context.Background())

}
