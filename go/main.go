package main

import (
	"fmt"
	"time"
)

type Person struct {
	first_name string
	last_name  string
	age        int
}

func (p Person) changePerson() (Person, error) {
	return Person{"John", "White", 3}, nil
}

func main() {

	var person Person = Person{"a", "b", 3}
	var e error = nil

	go func() {
		time.Sleep(3 * time.Second)
	}()

	// I think this would be a terrible thing
	// If there were not a garbage collector
	person, e = person.changePerson()
	fmt.Println(e)
	fmt.Printf("%s\n%s\n%d\n", person.first_name, person.last_name, person.age)
}
