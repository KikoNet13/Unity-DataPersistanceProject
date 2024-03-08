using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataEntry
{
    public int highScore;
    public string highScorePlayerName;
    public string playerName;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DataEntry data = new DataEntry();

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LoadData();
    }

    public void SetPlayerName(string name)
    {
        data.playerName = name;
        SaveData();
    }

    public bool CheckHighScore(int score)
    {
        if (score > data.highScore)
        {
            data.highScore = score;
            data.highScorePlayerName = data.playerName;
            return true;
        }
        return false;
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/data.json", json);

    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/data.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            data = JsonUtility.FromJson<DataEntry>(json);
        }
    }
}