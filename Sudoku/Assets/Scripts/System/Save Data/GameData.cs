using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<BoardCellData> Board;
    public int BoardIndex;
    public Difficulty Difficulty;

    public void SetBoard(BoardCell[] board)
    {
        Board.Clear();

        string boardToString = "";
        for (int i = 0; i < board.Length; i++)
        {
            BoardCellData cellData = new()
            {
                Number = board[i].Number,
                IsShown = board[i].IsShown
            };

            Board.Add(cellData);
            boardToString += cellData.Number + " " + cellData.IsShown;
        }

        Debug.Log(boardToString);
    }
}
[System.Serializable]
public class BoardCellData
{
    public int Number;
    public bool IsShown;
}
