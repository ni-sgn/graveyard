package main

import (
	"fmt"
	"io"
	"log"
	"net/http"
)

// There is a mistake in the code below
// I was trying to make send only channel
// insead I made a receive only channel
// but no one is sending anything
// hence it will be blocked, maybe until main thread exits
func getDataDeadlock(jobs chan int, result <-chan int) error {
	readingFromSendOnlyChannel := <-result
	fmt.Println(readingFromSendOnlyChannel)

	resp, err := http.Get("https://www.google.com")

	// I don't know what kind of error this is
	// string carries the specifics
	if err != nil {
		return err
	}
	defer resp.Body.Close()

	fmt.Println("Status:", resp.Status)
	fmt.Println("Headers:", resp.Header)
	body, err := io.ReadAll(resp.Body)
	if err != nil {
		return err
	}
	fmt.Println("Body:", string(body))

	return nil
}

func getData(jobs <-chan int, result chan<- int) error {
	resp, err := http.Get("https://www.google.com")

	// I don't know what kind of error this is
	// string carries the specifics
	if err != nil {
		return err
	}
	defer resp.Body.Close()

	fmt.Println("Status:", resp.Status)
	fmt.Println("Headers:", resp.Header)
	body, err := io.ReadAll(resp.Body)
	if err != nil {
		return err
	}
	fmt.Println("Body:", string(body))

	return nil
}

func main() {
	var (
		jobs    = make(chan int, 1)
		result  = make(chan int, 1)
		errChan = make(chan error)
	)

	// This causes deadlock because it will wait for
	// the resulf of the function which on the other hand
	// is waiting a data to be send in result channel to receive it
	/* if I send something to the channel it works fine result <- 1*/
	// which means that waiting for the function return also blocking
	// how is it different from receiving from the channel?
	// I'm dumb. It's blocking because I'm not running it as goroutine.
	//err := getDataDeadlock(jobs, result)
	// As goroutine
	go func() {
		errChan <- getDataDeadlock(jobs, result)
	}()
	err := <-errChan
	if err != nil {
		log.Println(err)
	}
}
