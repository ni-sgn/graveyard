package main

import (
	"encoding/json"
	"fmt"
	"json_example/models"
	"time"
)

func main() {

	// player
	item := models.Item{Name: "ჯოშუა", Dmg: 12312}
	player1 := models.Player{Name: "Player1", Health: 123, Items: []models.Item{item}}

	player2 := models.Player{Name: "Player2", Health: 123, Items: []models.Item{item}}

	fmt.Println(player2.Health)
	player1.Attack(&player2)
	fmt.Println(player2.Health)

	res, _ := json.Marshal(item)
	fmt.Printf("%d\n", res)
	fmt.Printf("%s\n", res)
	//!! important
	//this is a code points in unicode, it's represented
	//in hexadecimal, it needs only 1 byte
	fmt.Printf("\u20ac")
	//recieved, _ := http.Post("https://google.com", "application/json", bytes.NewBuffer(res))
	fmt.Println("")
	var pow = []int{1, 2, 3, 4, 5, 6, 7, 8, 4, 213, 42, 2, 314, 234, 12, 34, 1234, 123, 41, 234, 12, 34}

	// Race condition master!
	for _, v := range pow {
		go func() {
			v = 3
			fmt.Println(v)
		}()
	}

	time.Sleep(3 * time.Second)
}
