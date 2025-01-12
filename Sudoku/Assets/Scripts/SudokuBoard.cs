using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SudokuBoard : MonoBehaviour
{
    [SerializeField]
    private BoardCell[] boardCells;

    public void SetUpABoard(int[] boardToLine)
    {
        for (int i = 0; i < boardCells.Length; i++)
        {
            boardCells[i].SetNumber(boardToLine[i]);
        }
    }
}
