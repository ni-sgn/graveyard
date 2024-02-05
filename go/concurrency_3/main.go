package main

import (
	"fmt"
	"sync"
	"time"
)

func Logic(lock *sync.Mutex, i int) {
	// Without lock this i reaches higher number
	// what does that suggest?
	// Lock makes other threads wait
	// therefore two threds might be calling print at
	// the same time; Is not that a problem?
	lock.Lock()
	defer lock.Unlock()
	fmt.Printf("worker %d\n", i)
	time.Sleep(100 * time.Millisecond)
}

func main() {
	lock := sync.Mutex{}

	for i := 0; i < 3; i++ {
		go func(i int) {
			copy := i
			for {
				Logic(&lock, copy)
				copy += 1
			}
		}(i)
	}

	time.Sleep(10 * time.Second)
	fmt.Printf("Now, I'm gonna lock it from main thread")

	// When I lock here, if any goroutines are passed the lock
	// inside the Logic() function, they will finish executing
	// print, after that every worker that enters the function
	// will try to lock but it's already locked, hence
	// they will be blocked, when it gets unlocked from here
	// first gouroutine will equire the lock do its thing and
	// unlock, after which another goroutine will aquire the lock and so on...
	// but main thread will finish executing here and
	// everything will be destroied
	lock.Lock()
	time.Sleep(10 * time.Second)
	fmt.Printf("now I'm unlocking")
	lock.Unlock()
}
