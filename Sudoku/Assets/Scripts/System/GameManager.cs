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
    public Action<BoardCell> OnMakingMove;
    public Action OnFinishBoard;

    private SudokuGenerator generator;

    private void Start()
    {
        OnMakingError += ReduceEnergy;
        //OnFinishBoard += GenerateNewBoard;

        generator = GetComponent<SudokuGenerator>();

        var loadedData = SaveSystem.Instance.LoadData();

        //GenerateNewBoard();
        if (loadedData == null)
        {
            GenerateNewBoard();
        }
        else
        {
            board.SetUpABoard(loadedData.Board.ToArray());
        }
    }

    public void GenerateNewBoard()
    {
        generator.SetBoardData((int)Mathf.Sqrt(board.GetBoard().Length));

        var twoDArray = generator.GenerateBoard();

        int rows = twoDArray.GetLength(0);
        int cols = twoDArray.GetLength(1);

        // Створюємо одновимірний масив потрібного розміру
        int[] oneDArray = new int[rows * cols];

        // Перетворюємо двовимірний масив на одновимірний
        string board2ToString = "";
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                oneDArray[index] = twoDArray[i, j];
                index++;
                board2ToString += twoDArray[i, j] + " ";
            }
            board2ToString += "\n";
        }
        Debug.Log(board2ToString);

        string boardToString = "";
        for (int i = 0; i < oneDArray.Length; i++)
        {
            boardToString += oneDArray[i] + " ";
        }
        Debug.Log(boardToString);

        board.SetUpNewBoard(oneDArray);

        SaveSystem.Instance.SetData(board.GetBoard(), 0, Difficulty.None);
        SaveSystem.Instance.OnSave?.Invoke();
    }

    private void ReduceEnergy()
    {
        EnergyCounter--;
        energyCounterText.text = EnergyCounter.ToString();
    }

    public BoardCell[] GetBoard()
    {
        return board.GetBoard();
    }
}
