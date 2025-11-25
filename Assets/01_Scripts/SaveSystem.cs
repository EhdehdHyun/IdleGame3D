using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;
    private string savePath; //저장 경로

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            savePath = Application.persistentDataPath + "/savefile.json";
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Save(PlayerData data)
    {
        data.lastSaveTime = (float)DateTimeOffset.UtcNow.ToUnixTimeSeconds(); //현재 시간을 유닉스 타임스탬프로 저장

        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(savePath, json);
    }

    public PlayerData Load()
    {
        if (!File.Exists(savePath))
            return null;

        string json = File.ReadAllText(savePath);
        return JsonConvert.DeserializeObject<PlayerData>(json);
    }
}
