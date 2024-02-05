package main

import (
	"fmt"
	"time"
)

func A(text string) {
	fmt.Println(text)
}

func B(text string) {
	go A(text)
}

func main() {
	// This is a blocking call
	// will wait for A() to finish
	A("Blocking A")

	// This is a blocking call, which has non-blocking call inside of it
	// this complicates things
	B("Blocking B")
	time.Sleep(1 * time.Second)

	// This is a non-blocking call, execution will not be blocked
	// and will continue
	// but if A does not have synchronization inside it and it's a
	// library function, it would not be managable, hence we need to
	// create a wrapper function
	// I guess wrappers are good idea, because functions by default should be
	// blocking, unless they contain read/write? io bound work?
	go A("non-blocking A")

	// This is a non-blocking call, which has
	// non-blocking call inside of it
	// when would this be helpful
	// we can just go A(), why should we spawn a goroutine
	// which spawns a goroutine; just spawn a goroutine directly
	go B("non-blocking B")

	// Instead of go A(), we can have go C(), which then
	// blockingly calls A(), and that would be a wrapper
	// I guess that would help us to separate synchronization logic
	// from A()'s logic

}
