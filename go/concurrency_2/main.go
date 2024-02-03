package main

import (
	"fmt"
	"time"
)

func main() {
	channel := make(chan bool, 1)

	go func() {
		for {
			val, ok := <-channel
			if !ok {
				fmt.Println("Channel has been closed")
				break
			}
			fmt.Println(val)
		}
	}()

	channel <- true
	channel <- false

	//val := <-channel
	close(channel)
	time.Sleep(time.Second)

	fmt.Println("End")
}
