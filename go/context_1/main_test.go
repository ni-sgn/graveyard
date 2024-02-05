package main

import (
	"context"
	"net/http"
	"testing"
)

func TestNewRequestWithContext(t *testing.T) {
	ctx, cancel := context.WithTimeout(context.Background(), 3)
	defer cancel()

	req, err := http.NewRequestWithContext(ctx, "GET", "https://www.google.com", nil)
	if err != nil {
		t.Fatal("Error creating request:", err)
	}

	if req.Body != nil {
		t.Error("Expected req.Body to be nil")
	}
}
