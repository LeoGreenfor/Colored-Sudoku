using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SudokuBoard : MonoBehaviour
{
    [SerializeField]
    private BoardCell[] boardCells;

    public void SetUpNewBoard(int[] boardToLine)
    {
        // set numbers&colors on board
        var colorPallets = GameManager.Instance.ColorPalletsCollection.Pallets;
        var pallet = colorPallets[Random.Range(0, colorPallets.Length)];
        for (int i = 0; i < boardCells.Length; i++)
        {
            boardCells[i].SetNumber(boardToLine[i]);

            Color[] cellColors = pallet.colors;
            boardCells[i].SetSolvedColor(cellColors[Random.Range(0, cellColors.Length)]);
        }

        // show specific number of numbers
        int counter = 0;

        while(counter < GameManager.Instance.MinimumShownNumbers)
        {
            int currentIndex = Random.Range(0, boardToLine.Length);

            if (!boardCells[currentIndex].IsShown) 
            {
                counter++;
                boardCells[currentIndex].ShowNumber();
            }
        }
    }

    public void SetUpABoard(BoardCellData[] board)
    {
        for (int i = 0; i < boardCells.Length; i++)
        {
            boardCells[i].SetNumber(board[i].Number);
            boardCells[i].IsShown = board[i].IsShown;

            //Debug.Log(boardCells[i].Number + " " + boardCells[i].IsShown);
        }
    }

    public BoardCell[] GetBoard()
    {
        return boardCells;
    }
}
