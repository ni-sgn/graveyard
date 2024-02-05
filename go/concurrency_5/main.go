package main

import (
	"fmt"
	"io"
	"log"
	"net/http"
	"os"
	"sync"
)

// Just checking out
type StringCallback func(int) (string, error)

func WriteToFile(filename string, data []byte) error {
	file, err := os.Create(filename)
	if err != nil {
		return err
	}
	defer file.Close()

	_, err = file.Write(data)
	return err
}

func GetCall(url string) ([]byte, error) {
	resp, err := http.Get(url)
	if err != nil {
		return nil, err
	}
	defer resp.Body.Close()

	fmt.Println("Status code:", resp.StatusCode)
	// We have to ReadAll
	// ReadAll takes reader, reader returns
	// Status, (finished or not), ReadAll know
	// how to understand those statuses and
	// how to act to read the whole response
	sink, err := io.ReadAll(resp.Body)
	if err != nil {
		return nil, err
	}
	return sink, nil
}

func main() {
	var result = make(chan []byte, 1)
	//One way to wait
	var finished = make(chan bool)

	// Another way to wait
	var wg sync.WaitGroup

	// This will add the goroutine to the queue
	wg.Add(1)
	go func(url string) {
		data, err := GetCall(url)
		if err != nil {
			log.Fatalln("Could not get call")
		}
		fmt.Println("Successfully retrieved data")
		result <- data
	}("https://www.google.com")

	go func() {
		defer wg.Done()
		// Here if there is no result
		// this goroutine will wait(blocked)
		// does that guarantee synchronization?
		res := <-result
		err := WriteToFile("myfile.txt", res)
		if err != nil {
			log.Fatalln("Could not write to file")
		}
		fmt.Println("File written successfully")

		// When the channel is filled up, this routine gets blocked
		// until someone takes an item from the channel.
		// which means that, deferred functions do not get executed.
		// which means that defer wg.Done() does not get executed
		// hence the deadlock, because wg.Wait() will wait forever
		// while no one will recieve from the finished channel.
		finished <- true
	}()

	// No reason to use both of them
	// I'm just testing. <-finished prevents deadlock
	<-finished
	wg.Wait()
	close(finished)
	close(result)
}
