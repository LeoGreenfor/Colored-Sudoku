using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

[RequireComponent(typeof(SudokuGenerator))]
public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

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

    private void ReduceEnergy()
    {
        EnergyCounter--;
        energyCounterText.text = EnergyCounter.ToString();
    }
}
