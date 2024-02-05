package main

import (
<<<<<<< HEAD
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
=======
	"database/sql"
	"fmt"
	"time"

	_ "github.com/microsoft/go-mssqldb"
)

var schema string = ` 
	insert into dbo.Atoms (Id, Title, Body, Dt) values (1, 'hello', 'world', GETDATE())
	insert into dbo.Atoms (Id, Title, Body, Dt) values (2, 'hello', 'world', GETDATE())
	insert into dbo.Atoms (Id, Title, Body, Dt) values (3, 'hello', 'world', GETDATE())
`

func Init(db *sql.DB) error {
	_, err := db.Exec(schema)
	if err != nil {
		return err
	}
	return nil
}

func GetDataAndPrint(db *sql.DB) error {
	rows, err := db.Query(`select * from dbo.atoms`)
	defer rows.Close()
	if err != nil {
		return err
	}
	var (
		str1 string
		str2 string
		id   int
		dt   time.Time
	)

	for rows.Next() {
		rows.Scan(&id, &str1, &str2, &dt)
		fmt.Println(id, str1, str2, dt)
	}
>>>>>>> c9b8acb30eedad9b845040824ef0ac3ae93e8f04

	return nil
}

func main() {
<<<<<<< HEAD
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
=======
	db, err := sql.Open("mssql", "server=localhost; port=1433; user id=SA; password=P@ssw0rd; database=projects;")
	if err != nil {
		panic(err)
	}

	/*
		err = Init(db)
	*/

	err = GetDataAndPrint(db)
	if err != nil {
		panic(err)
>>>>>>> c9b8acb30eedad9b845040824ef0ac3ae93e8f04
	}
}
