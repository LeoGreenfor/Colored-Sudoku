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
        var colorPallets = GameManager.Instance.ColorPalletsCollection.Pallets;
        var pallet = colorPallets[Random.Range(0, colorPallets.Length)];
        // set numbers&colors on board
        for (int i = 0; i < boardCells.Length; i++)
        {
            boardCells[i].SetNumber(boardToLine[i]);

            Color[] cellColors = pallet.colors;
            boardCells[i].SetColor(cellColors[Random.Range(0, cellColors.Length)]);
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
}
