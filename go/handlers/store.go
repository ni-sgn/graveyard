package main

import "fmt"

type Service interface {
	Create(int) error
}

type Instance struct {
	Id string
}

func (i *Instance) Create(id int) error {
	i.Id = fmt.Sprintf("created %d", id)
	return nil
}
