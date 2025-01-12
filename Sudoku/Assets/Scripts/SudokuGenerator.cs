using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SudokuGenerator : MonoBehaviour
{
    private int[,] board;
    private List<int> _staticNumbers;
    private int _boardSize;

    private void Start()
    {
        // for testing
        SetBoardData(9);

        GenerateBoard(_boardSize);
    }

    public void SetBoardData(int boardSize)
    {
        _boardSize = boardSize;

        for(int i = 1; i <= boardSize; i++) 
            _staticNumbers.Add(i);
    }
    
    public int[,] GenerateBoard(int size)
    {
        board = new int[size, size];

        FillBoard(0, 0);
        /*if (FillBoard(0, 0))
        {
            Debug.Log("Sudoku board generated successfully!");

            string boardToString = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    boardToString += board[i, j] + " ";
                }
                boardToString += "\n";
            }
            Debug.Log(boardToString);
        }
        else
        {
            Debug.LogError("Failed to generate Sudoku board.");
        }*/

        return board;
    }

    private bool FillBoard(int row, int col)
    {
        int size = board.GetLength(0);

        // якщо ми дос€гли к≥нц€ таблиц≥, повертаЇмо усп≥х
        if (row == size)
        {
            return true;
        }

        // ѕереходимо до наступного р€дка п≥сл€ завершенн€ стовпц€
        if (col == size)
        {
            return FillBoard(row + 1, 0);
        }

        // —пробуЇмо вставити числа в≥д 1 до 9
        List<int> numbers = new List<int>(_staticNumbers);
        Shuffle(numbers); // ѕерем≥шуЇмо числа дл€ рандом≥зац≥њ

        foreach (int num in numbers)
        {
            if (IsValid(row, col, num))
            {
                board[row, col] = num;

                // –екурсивний виклик дл€ заповненн€ наступноњ кл≥тинки
                if (FillBoard(row, col + 1))
                {
                    return true;
                }

                // якщо вставка числа призвела до помилки, скидаЇмо кл≥тинку
                board[row, col] = 0;
            }
        }

        // якщо жодне число не п≥дходить, повертаЇмос€ назад
        return false;
    }
    private bool IsValid(int row, int col, int num)
    {
        int size = board.GetLength(0);
        int boxSize = (int)Mathf.Sqrt(size);

        // ѕерев≥рка р€дка
        for (int i = 0; i < size; i++)
        {
            if (board[row, i] == num) return false;
        }

        // ѕерев≥рка стовпц€
        for (int i = 0; i < size; i++)
        {
            if (board[i, col] == num) return false;
        }

        // ѕерев≥рка сектора (3x3)
        int startRow = (row / boxSize) * boxSize;
        int startCol = (col / boxSize) * boxSize;

        for (int i = 0; i < boxSize; i++)
        {
            for (int j = 0; j < boxSize; j++)
            {
                if (board[startRow + i, startCol + j] == num) return false;
            }
        }

        return true;
    }

    private void Shuffle(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
