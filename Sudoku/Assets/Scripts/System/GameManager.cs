using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

[RequireComponent(typeof(SudokuGenerator))]
public class GameManager : Singleton<GameManager>
{
    public ColorPalletsCollection ColorPalletsCollection;

    [Header("Sudoku Board Settings")]
    [SerializeField]
    private SudokuBoard board;
    public int CurrentCheckedNumber;
    public int MinimumShownNumbers;

    [Header("Energy Config")]
    public int EnergyCounter = 100;
    [SerializeField]
    private TMP_Text energyCounterText;
    public Action OnMakingError;

    private SudokuGenerator generator;

    private void Start()
    {
        OnMakingError += ReduceEnergy;

        generator = GetComponent<SudokuGenerator>();

        var loadedData = SaveSystem.Instance.LoadData();

        if (loadedData == null)
        {
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

            board.SetUpNewBoard(oneDArray);

            SaveSystem.Instance.SetData(board.GetBoard(), 0, Difficulty.None);
            SaveSystem.Instance.Save();
        }
        else
        {
            board.SetUpABoard(loadedData.Board.ToArray());
        }
    }

    private void ReduceEnergy()
    {
        EnergyCounter--;
        energyCounterText.text = EnergyCounter.ToString();
    }
}
