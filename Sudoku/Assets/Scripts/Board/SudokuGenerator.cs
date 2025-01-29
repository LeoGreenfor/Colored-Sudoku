using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SudokuGenerator : MonoBehaviour
{
    private int[,] board;
    private List<int> _staticNumbers;
    private int boxSize;
    private int _boardSize;

    private void Start()
    {
        // for testing
        Debug.Log(_boardSize);
    }
    public void SetBoardData(int boardSize)
    {
        _boardSize = boardSize;
        Debug.Log(_boardSize);
        boxSize = (int)Mathf.Sqrt(_boardSize);
        _staticNumbers = new List<int>();

        for (int i = 1; i <= _boardSize; i++)
            _staticNumbers.Add(i);
    }

    public int[,] GenerateBoard()
    {
        board = new int[_boardSize, _boardSize];

        // 1. Заповнюємо головну діагональ секторами (3x3)
        for (int i = 0; i < _boardSize; i += boxSize)
        {
            FillBox(i, i);
        }

        // 2. Заповнюємо решту таблиці
        if (!FillBoard(0, 0))
        {
            Debug.LogError("Failed to generate a valid Sudoku board.");
        }

        return board;
    }

    private bool FillBoard(int row, int col)
    {
        // Вийшли за межі таблиці
        if (row == _boardSize)
            return true;

        // Переходимо до нового рядка
        if (col == _boardSize)
            return FillBoard(row + 1, 0);

        // Пропускаємо попередньо заповнені клітинки
        if (board[row, col] != 0)
            return FillBoard(row, col + 1);

        List<int> numbers = new List<int>(_staticNumbers);
        Shuffle(numbers);

        foreach (int num in numbers)
        {
            if (IsValid(row, col, num))
            {
                board[row, col] = num;

                if (FillBoard(row, col + 1))
                    return true;

                board[row, col] = 0; // Відкат змін
            }
        }

        return false; // Немає можливого значення
    }

    private void FillBox(int startRow, int startCol)
    {
        List<int> numbers = new List<int>(_staticNumbers);
        Shuffle(numbers);

        int index = 0;
        for (int i = 0; i < boxSize; i++)
        {
            for (int j = 0; j < boxSize; j++)
            {
                board[startRow + i, startCol + j] = numbers[index++];
            }
        }
    }

    private bool IsValid(int row, int col, int num)
    {
        // Перевірка рядка та стовпця
        for (int i = 0; i < _boardSize; i++)
        {
            if (board[row, i] == num || board[i, col] == num)
                return false;
        }

        // Перевірка сектора (3x3)
        int startRow = (row / boxSize) * boxSize;
        int startCol = (col / boxSize) * boxSize;

        for (int i = 0; i < boxSize; i++)
        {
            for (int j = 0; j < boxSize; j++)
            {
                if (board[startRow + i, startCol + j] == num)
                    return false;
            }
        }

        return true;
    }

    private void Shuffle(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            (list[i], list[randomIndex]) = (list[randomIndex], list[i]);
        }
    }
}
