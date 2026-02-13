package main

import (
	"fmt"
)

func main() {

	var quantity int

	fmt.Println("Введите кол-во переменных для подсчета произведения: ")
	for {
		_, err := fmt.Scan(&quantity)
		if err != nil {
			fmt.Println("Ошибка! Введите целое положительное число")
			var trash string 
			fmt.Scan(&trash)
			continue
		}
		if quantity <= 0 {
			fmt.Println("Ошибка! Число должно быть больше 0")
        	continue
		}
		break
	}

	var multiplier int
	sum := 1
	for i := 0; i < quantity; i++ {
		fmt.Printf("Осталось ввести чисел: %d\n", quantity-i)
		fmt.Println("Ввидет целое положительное число: ")
		for {
			_, err := fmt.Scan(&multiplier)
			if err != nil {
				fmt.Println("Ошибка! Введите целое положительное число")
				var trash string 
				fmt.Scan(&trash)
				continue
			}
			if quantity <= 0 {
				fmt.Println("Ошибка! Число должно быть больше 0")
        		continue
			}
			break
		}
		sum = sum * multiplier
	}
	fmt.Printf("\n\nРезультат: %d", sum)
}
