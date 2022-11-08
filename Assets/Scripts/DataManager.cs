using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;
    public int HighScore;
    public string HighScorePlayerName;

    private string FilePath;
    
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        FilePath = Application.persistentDataPath + "/SaveData.json";
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.LastPlayerName = Instance.PlayerName;
        data.HighScore = HighScore;
        data.HighScorePlayerName = HighScorePlayerName;
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(FilePath, json);
    }
    
    [Serializable]
    class SaveData
    {
        public string LastPlayerName;
        public string HighScorePlayerName;
        public int HighScore;
    }
}
