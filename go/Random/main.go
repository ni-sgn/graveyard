package main

import (
	"encoding/json"
	"fmt"
	"time"

	"github.com/nikasept/go-api/dtos"
)

func addition(x int, y int) int {
	fmt.Println("hello, this is asynchronous")
	return x + y
}

func additionSum(x int, y int) int {
	fmt.Println("hello, this is asynchronous")

	switch {
	case x > 0 && y > 0:
		return x + y
	default:
		panic("Yoo, Why you giving me a smallball number")
	}
}

type myinterface interface {
	int | float64
}

func additionGeneric[T myinterface](a T, b T) T {
	return a + b
}

type Geometry struct {
	Perimeter float64 `json:"perimeter"`
	Area      float64 `json:"area"`
}

func (geo *Geometry) Serialize() ([]byte, error) {
	bts, err := json.Marshal(*geo)
	if err != nil {
		fmt.Printf("Somehting went wrong")
		return nil, err
	}

	return bts, nil
}

func main() {

	var person dtos.Person = dtos.Person{First_name: "a", Last_name: "b", Age: 3}
	//chan_1 := make(chan string)

	var geo Geometry = Geometry{Area: 3.14 * (3 * 3) / 2, Perimeter: 2 * 3.14 * 3}
	var geoFromWeb Geometry

	jsoned, _ := geo.Serialize()

	fmt.Println(jsoned)
	err := json.Unmarshal(jsoned, &geoFromWeb)
	if err != nil {
		fmt.Println(err)
	}
	fmt.Println(geoFromWeb.Area)

	fmt.Println(additionGeneric(3.2, 3.4))
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
	time.Sleep(1 / 100 * time.Second)

	// I think this would be a terrible thing
	// If there were not a garbage collector
	fmt.Printf("%s\n%s\n%d\n", person.First_name, person.Last_name, person.Age)
	fmt.Println(additionSum(10, -1))

}
