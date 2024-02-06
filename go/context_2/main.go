package main

import (
	"context"
	"fmt"
	"time"
)

func IDoStuff(ctx context.Context) {

	// How is selected implemented?
	// it should be looping throug
	// checking if any of the ques is
	// unlocked and populated to grap an item
	select {
	case <-ctx.Done():
		fmt.Println("I have been cancelled")
	case <-time.After(4 * time.Second):
		fmt.Println("I did le chose")
	}
}

func main() {
	// When function pointers are being returned
	// they have the access to the
	// original variables of the context?
	ctx, cancel := context.WithCancel(context.Background())

	go IDoStuff(ctx)
	cancel()
	time.Sleep(3 * time.Second)
}
