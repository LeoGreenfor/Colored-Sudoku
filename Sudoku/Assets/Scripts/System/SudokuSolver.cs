using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SudokuBoard))]
public class SudokuSolver : MonoBehaviour
{
    private SudokuBoard _board;
    public int _solvedCellCount;

    private void Start()
    {
        _board = GetComponent<SudokuBoard>();

        _solvedCellCount = GameManager.Instance.MinimumShownNumbers;
        GameManager.Instance.OnMakingMove += CheckIfSolve;
    }

    private void CheckIfSolve(BoardCell cell)
    {
        _solvedCellCount += cell.IsShown ? 1 : 0;
        if (_solvedCellCount >= _board.GetBoard().Length)
        {
            FinishBoard();
        }
    }
    private void FinishBoard()
    {
        Debug.Log("FINISH");
        //add board to gallery
        _board.ShowUpColors();

        //GameManager.Instance.GenerateNewBoard();
    }
}
