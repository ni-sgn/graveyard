package main

import (
	"context"
	"net/http"
)

// This is a wrapper for a middleware
// it makes able to pass specific variables to the middleware
// that can be used in the middleware
func Middleware(mw_specific_value_1 int, mw_specific_value_2 string) func(http.Handler) http.Handler {
	return func(next http.Handler) http.Handler {
		return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
			// this is middleware specific logic
			// we are changing the request down the line
			new_r := r.WithContext(context.WithValue(r.Context(), "mw_specific_value_1", mw_specific_value_1))

			next.ServeHTTP(w, new_r)
		})
	}
}
