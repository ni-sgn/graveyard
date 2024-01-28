package interfaces

import "github.com/nikasept/go-api/dtos"

type Education interface {
	Enroll(person dtos.Person) int
	Leave(person dtos.Person) error
}
