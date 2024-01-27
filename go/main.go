package main

import (
	"fmt"
	"time"

	"github.com/nikasept/go-api/dtos"
)

func addition(x int, y int) int {
	fmt.Println("hello, this is asynchronous")
	return x + y
}

func main() {

	var person dtos.Person = dtos.Person{First_name: "a", Last_name: "b", Age: 3}
	var point *dtos.Person = &person
	//chan_1 := make(chan string)

	go func() {
		for {
			time.Sleep(1 / 100 * time.Second)
			fmt.Println("Concurrent print")
			//chan_1 <- "I'm finish executing an concurrent print"
		}
	}()

	go addition(3, 4)

	fmt.Println("Current thread exec")

	//val_from_concurrent := <-chan_1
	//fmt.Println(val_from_concurrent)
	time.Sleep(10 * time.Second)

	// I think this would be a terrible thing
	// If there were not a garbage collector
	person, _ = dtos.ChangePerson(point)

	fmt.Printf("%s\n%s\n%d\n", person.First_name, person.Last_name, person.Age)

}
