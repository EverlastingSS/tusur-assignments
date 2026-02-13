package main

import (
	"fmt"
	"math"
)

func main() {
	var n int

	fmt.Print("Введите количество элементов: ")
	_, err := fmt.Scan(&n)
	if err != nil || n <= 0 {
		fmt.Println("Ошибка! Некорректное количество элементов.")
		return
	}

	arr := make([]float64, n)

	fmt.Println("Введите элементы массива:")
	for i := 0; i < n; i++ {
		_, err := fmt.Scan(&arr[i])
		if err != nil {
			fmt.Println("Ошибка! Некорректный ввод элемента массива.")
			return
		}
	}

	// минимальный
	min := arr[0]
	for i := 1; i < n; i++ {
		if arr[i] < min {
			min = arr[i]
		}
	}

	// сумма элементов до первого положительного
	sum := 0.0
	for i := 0; i < n; i++ {
		if arr[i] > 0 {
			break
		}
		sum += arr[i]
	}

	var a, b float64
	fmt.Println("Введите границы интервалов (a и b): ")
	_, err = fmt.Scan(&a, &b)
	if err != nil {
		fmt.Println("Ошибка! Некорректный ввод интервала")
		return
	}

	if a > b {
		fmt.Println("Ошибка! Значение a должно быть меньше или равно b")
		return
	}

	// сжатие
	newArr := make([]float64, n)
	index := 0

	for i := 0; i < n; i++ {
		absValue := math.Abs(arr[i])
		if absValue < a || absValue > b {
			newArr[index] = arr[i]
			index++
		}
	}

	
	fmt.Println("\nМинимальный элемент:", min)
	fmt.Println("Сумма до первого положительного:", sum)

	fmt.Println("Массив после сжатия:")
	for i := 0; i < n; i++ {
		fmt.Print(newArr[i], " ")
	}
}
