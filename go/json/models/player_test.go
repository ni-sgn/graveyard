package models

import "testing"

func TestPlayer(t *testing.T) {
	name := "John"
	if name != "Player1" {
		t.Fatal("Nah, this is wrong, test failed")
	}
}
