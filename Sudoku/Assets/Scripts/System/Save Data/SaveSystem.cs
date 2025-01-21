using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : Singleton<SaveSystem>
{
    #region Settings
    [SerializeField]
    private string saveFilePath;
    #endregion
    #region Board info
    public GameData CurrentData;
    #endregion

    public Action OnSave;

    protected override void Awake()
    {
        base.Awake();
        OnSave += Save;

        Debug.Log(Application.persistentDataPath + saveFilePath);
    }

    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, saveFilePath);
        
        if (File.Exists(path)) File.Delete(path);

        FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);

        formatter.Serialize(fileStream, CurrentData);
        fileStream.Close();
    }
    public void SetData(BoardCell[] board, int boardIndex, Difficulty difficulty)
    {
        CurrentData.SetBoard(board);
        CurrentData.BoardIndex = boardIndex;
        CurrentData.Difficulty = difficulty;
    }
    public GameData LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string filePath = Path.Combine(Application.persistentDataPath, saveFilePath);

        if (System.IO.File.Exists(filePath))
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                var restoredData = formatter.Deserialize(stream) as GameData;
                CurrentData = restoredData;
                return restoredData;
            }
        }
        else
        {
            return null;
        }
    }
   /* public void Restore(Data gameData)
    {
        if (gameData is not Data)
        {
            Debug.LogError($"Unknown memento implementation found: {gameData.GetType().FullName}");
            return;
        }

        PlayerSide = gameData.GetPlayerChessSide();

        var player = FindFirstObjectByType<PlayerMovementController>()?.GetComponent<Player>();
        PlayerData = gameData.GetPlayer();
        player?.SetStats(LastLevelNumber, player.transform);

        LastLevelNumber = gameData.GetLastLevelNumber();
    }*/

    private void OnDestroy()
    {
        OnSave -= Save;
    }
}
