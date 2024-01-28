package dtos

type Person struct {
	First_name string
	Last_name  string
	Age        int
}

func ChangePerson(p *Person) error {
	someOther := Person{"a", "b", 3}
	p = &someOther

	return nil
}
