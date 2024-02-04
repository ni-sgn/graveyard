package main

import (
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

	return nil
}

func main() {
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
	}
}
