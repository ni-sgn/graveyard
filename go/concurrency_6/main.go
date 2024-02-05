package main

import (
	"database/sql"
	"fmt"
	"log"
	"sync"
	"time"

	_ "github.com/microsoft/go-mssqldb"
)

type Atom struct {
	Id     int
	Header string
	Body   string
	DT     time.Time
}

// Every thread will enter this function
// and they will modify wg counter when they are finished
// this is good if we want to make sure that some group of
// actions are finished.
// wg does not protect segments of code from
// simultanious access, which mutex does.
func Select(db *sql.DB, wg *sync.WaitGroup) error {
	rows, err := db.Query(`
	select * from dbo.Atoms
	`)

	if err != nil {
		return err
	}

	atom := Atom{}
	for rows.Next() {
		rows.Scan(&atom.Id, &atom.Header, &atom.Body, &atom.DT)
	}

	fmt.Println(atom)
	wg.Done()
	return nil
}

func main() {
	db, err := sql.Open("mssql", "server=localhost; user id=SA; password=P@ssw0rd; port=1433; database=projects;")
	if err != nil {
		log.Fatalln(err)
	}

	if err != nil {
		log.Fatalln(err)
	}

	wg := sync.WaitGroup{}

	for i := 0; i < 100; i++ {
		// This specific wait group 'object' is being raised
		// by one for each goroutine. It is also passed to that
		// go routine, which when finished decrements it
		// wg.Wait will wait until wg counter becomes 0
		wg.Add(1)
		go Select(db, &wg)
	}

	wg.Wait()
}
