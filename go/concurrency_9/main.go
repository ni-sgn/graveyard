package main

import (
	"fmt"
	"time"
)

func addition(res chan string) {
	time.Sleep(10 * time.Second)
	res <- "hello"
}

func main() {
	cha := make(chan string)

	go addition(cha)
	ans := <-cha
	fmt.Println(ans)
}
