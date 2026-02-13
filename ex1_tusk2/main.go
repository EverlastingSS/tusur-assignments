package main

import (
	"fmt"
	"math"
)

func main() {

	var number int
	fmt.Println("Введите значение N: ")
	for {
		_, err := fmt.Scan(&number) 
		if err != nil || number <= 0 {
			fmt.Println("Ошибка! Введите целое положительное число")
			continue
		}
		break
	}

	key := 1
	for {
		if float64(key) > float64(number)+math.Sqrt(float64(number)) {
			break
		}
		key++
	}
	
	fmt.Println("Минимальный возможный K: ", key)
}