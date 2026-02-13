package main

import (
	"fmt"
	"math"
	"os"
)

func triangleArea(x1, y1, x2, y2, x3, y3 float64) float64 {
	return 0.5 * math.Abs(x1*(y2-y3)+x2*(y3-y1)+x3*(y1-y2))
}

func readFloat(prompt string) float64 {
	var value float64
	for {
		fmt.Print(prompt)
		_, err := fmt.Scan(&value)
		if err == nil {
			return value
		}
		fmt.Println("Ошибка ввода. Програма закрывается")
		os.Exit(0)
	}
}

func main() {
	fmt.Println("\nПервый  треугольничек <3")
	x1 := readFloat("Введите x1: ")
	y1 := readFloat("Введите y1: ")
	x2 := readFloat("Введите x2: ")
	y2 := readFloat("Введите y2: ")
	x3 := readFloat("Введите x3: ")
	y3 := readFloat("Введите y3: ")

	area1 := triangleArea(x1, y1, x2, y2, x3, y3)

	fmt.Println("\nВторой, менее прекрасный треугольник")
	x4 := readFloat("Введите x1: ")
	y4 := readFloat("Введите y1: ")
	x5 := readFloat("Введите x2: ")
	y5 := readFloat("Введите y2: ")
	x6 := readFloat("Введите x3: ")
	y6 := readFloat("Введите y3: ")

	area2 := triangleArea(x4, y4, x5, y5, x6, y6)

	fmt.Printf("\nПлощадь первого треугольника: %.2f\n", area1)
	fmt.Printf("Площадь второго треугольника: %.2f\n", area2)

	if area1 > area2 {
		fmt.Println("Первый треугольник больше")
	} else if area2 > area1 {
		fmt.Println("Второй треугольник больше")
	} else {
		fmt.Println("Площади треугольников равны.")
	}
}
