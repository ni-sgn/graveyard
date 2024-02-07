package main

import "context"

func main() {
	var store Service = &Instance{Id: "id"}
	ctx := context.WithValue(context.Background(), "store", store)
	InitServer(ctx)
}
