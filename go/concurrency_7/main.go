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

func Select(db *sql.DB) error {
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
	return nil
}

// not parallel, just non-blocking
func DoJob(jobs <-chan int, results chan<- int) {
	fmt.Println("initializing worker")
	for job := range jobs {
		res := job * 2
		fmt.Println("I'm doing some job", res)
		results <- res
	}
}

// lets implement wg functionality
// using mutexes
func main() {
	jobs := make(chan int, 10)
	results := make(chan int, 10)
	db, err := sql.Open("mssql", "server=localhost; user id=SA; password=P@ssw0rd; port=1433; database=projects;")
	_ = db
	if err != nil {
		log.Fatalln(err)
	}

	if err != nil {
		log.Fatalln(err)
	}

	// deez nuts
	for i := 0; i < 100; i++ {
		//go Select(db)
	}

	const worker_number = 3
	var wg sync.WaitGroup
	for i := 0; i < worker_number; i++ {
		wg.Add(1)
		go func() {
			defer wg.Done()
			// If I go DoJob(...) things get weird
			// I should think about this
			// which means that creating goroutine in a goroutine is
			// different that syncrhnous call from a goroutine
			// THAT IS BECAUSE WE ARE NOT WATING FOR DoJob(...)
			// TO FINISH FOR DEFERRED wg.Done() to be called
			// instead it is called before DoJob(...) is exited
			// DoJob(jobs, results)
			DoJob(jobs, results)
		}()
	}

	// Send jobs to the workers
	for j := 1; j <= 10; j++ {
		jobs <- j
	}
	// we are not going to add more items
	// in this queue
	close(jobs)

	wg.Wait()
	// after jobs are done
	// there won't be any results appearing in the channel
	close(results)

	for r := range results {
		fmt.Println(r)
	}

}
