package main

import (
	"fmt"
	"os"
	"strconv"
)

func main() {
	var input string

	fmt.Print("Введите вещественное число: ")
	fmt.Scan(&input)


	_, err := strconv.ParseFloat(input, 64)
	if err != nil {
		fmt.Println("Ошибка! Программа закрывается :>")
		os.Exit(0)
	}

	sum := 0

	for _, ch := range input {
		if ch >= '0' && ch <= '9' {
			sum += int(ch - '0')
		}
	}

	fmt.Println("Сумма цифр:", sum)
}
