package main

import (
	"fmt"
)

func main() {
	var rows, cols int

	fmt.Print("Введите количество строк: ")
	_, err := fmt.Scan(&rows)
	if err != nil || rows <= 0 {
		fmt.Println("Ошибка! Некорректное количество строк.")
		return
	}

	fmt.Print("Введите количество столбцов: ")
	_, err = fmt.Scan(&cols)
	if err != nil || cols <= 0 {
		fmt.Println("Ошибка! Некорректное количество столбцов.")
		return
	}

	
	matrix := make([][]float64, rows)
	for i := 0; i < rows; i++ {
		matrix[i] = make([]float64, cols)
	}

	fmt.Println("Введите элементы матрицы построчно:")

	for i := 0; i < rows; i++ {
		for j := 0; j < cols; j++ {
			_, err := fmt.Scan(&matrix[i][j])
			if err != nil {
				fmt.Println("Ошибка! Некорректный ввод элемента.")
				return
			}
		}
	}

	var row1, row2 int
	fmt.Print("Введите номера двух строк для обмена (нумерация с 1) через пробел: ")
	_, err = fmt.Scan(&row1, &row2)
	if err != nil {
		fmt.Println("Ошибка! Некорректный ввод номеров строк.")
		return
	}


	if row1 < 1 || row1 > rows || row2 < 1 || row2 > rows {
		fmt.Println("Ошибка! Номера строк вне диапазона.")
		return
	}

	row1--
	row2--

	matrix[row1], matrix[row2] = matrix[row2], matrix[row1]

	fmt.Println("Матрица после обмена строк:")

	for i := 0; i < rows; i++ {
		for j := 0; j < cols; j++ {
			fmt.Print(matrix[i][j], "\t")
		}
		fmt.Println()
	}
}
