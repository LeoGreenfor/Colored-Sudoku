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

    [Serializable]
    class BoardCell
    {
        public int Number;
        public Button Button;
        public TMP_Text Text;
    }

    private void SetUpABoard(int[] boardToLine)
    {
        for (int i = 0; i < boardCells.Length; i++)
        {
            boardCells[i].Number = boardToLine[i];
        }
    }
}
