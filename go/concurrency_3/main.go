package main

import (
	"fmt"
	"sync"
	"time"
)

func main() {

	lock := sync.Mutex{}
	lock.Lock()
	for i := 0; i < 3; i++ {
		go func(i int) {
			for {
				fmt.Printf("worker %d\n", i)
				time.Sleep(100 * time.Millisecond)
			}
		}(i)
	}

	time.Sleep(10 * time.Second)
}
