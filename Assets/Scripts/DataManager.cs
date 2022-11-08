using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Rendering;
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
        Load();
    }

    public void Load()
    {
        if (File.Exists(FilePath))
        {
            var text = File.ReadAllText(FilePath);
            var data = JsonUtility.FromJson<SaveData>(text);
            Debug.Log(text);

            HighScore = data.HighScore;
            HighScorePlayerName = data.HighScorePlayerName;
        }
    }
    
    public void Save()
    {
        SaveData data = new SaveData();
        data.LastPlayerName = Instance.PlayerName;
        data.HighScore = HighScore;
        data.HighScorePlayerName = HighScorePlayerName;
        var json = JsonUtility.ToJson(data);
        Debug.Log(json);
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
