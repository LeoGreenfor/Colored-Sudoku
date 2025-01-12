using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SudokuGenerator : MonoBehaviour
{
    private List<int> _staticNumbers;

    private void Start()
    {
        _staticNumbers = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};
        
        GenerateBoard(9, 9);
    }
    
    public void GenerateBoard(int cells, int rows)
    {
        List<int> numbers = new List<int>();
        int[,] board = new int[cells, rows];

        for (int i = 0; i < rows; i++)
        {
            numbers.AddRange(_staticNumbers);
            Debug.Log(numbers.Count);
            int currentNumber = ChooseRandomNumber(numbers);

            for (int j = 0; j < cells; j++)
            {
                board[i, j] = currentNumber;
                numbers.Remove(currentNumber);
                if (numbers.Count > 0) currentNumber = ChooseRandomNumber(numbers);
            }
        }

        string boardToString = "";
        for (int i = 0;i < cells; i++)
        {
            for (int j = 0; j < rows; j++)
                boardToString += board[i, j] + " ";
            boardToString += "\n";
        }

        Debug.Log(boardToString);
    }

    private int ChooseRandomNumber(List<int> numbers)
    {
        return numbers[Random.Range(0, numbers.Count)];
    }
}
