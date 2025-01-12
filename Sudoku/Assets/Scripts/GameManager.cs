using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

[RequireComponent(typeof(SudokuGenerator))]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SudokuBoard board;

    private SudokuGenerator generator;

    private void Start()
    {
        generator = GetComponent<SudokuGenerator>();
        generator.SetBoardData(9);

        var twoDArray = generator.GenerateBoard(9);

        int rows = twoDArray.GetLength(0);
        int cols = twoDArray.GetLength(1);

        // Створюємо одновимірний масив потрібного розміру
        int[] oneDArray = new int[rows * cols];

        // Перетворюємо двовимірний масив на одновимірний
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                oneDArray[index] = twoDArray[i, j];
                index++;
            }
        }

        string boardToString = "";
        for (int i = 0; i < oneDArray.Length; i++)
        {
            boardToString += oneDArray[i] + " ";
        }
        Debug.Log(boardToString);

        board.SetUpABoard(oneDArray);
    }
}
