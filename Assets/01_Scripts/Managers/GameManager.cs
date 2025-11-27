using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int level = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {

        PlayerData loaded = SaveSystem.Instance.Load();

        if (loaded == null)
        {
            loaded = new PlayerData();
            loaded.SetStat(StatType.Health, 100f);
            loaded.SetStat(StatType.Power, 5f);
            loaded.SetStat(StatType.AttackSpeed, 1f);
            loaded.SetStat(StatType.MoveSpeed, 2f);
            loaded.level = 0;
        }
        CharacterManager.Instance.playerData = loaded;
    }
}
