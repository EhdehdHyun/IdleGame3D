using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int day = 1;
    public int level = 0; //좀비 레벨 증가 용
    public int killCount = 0;
    public int killPerDay = 30;

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
        UIManager.Instance.UpdateUpgradeUI();

        var player = CharacterManager.Instance.player;
        if (player != null)
        {
            player.ApplyStats();
        }

        CharacterManager.Instance.player.currentHealth = CharacterManager.Instance.player.health;
    }

    public void OnKillEnemy()
    {
        killCount++;
        UIManager.Instance.UpdateKillCountUI();
        if (killCount >= killPerDay)
        {
            killCount = 0;
            killPerDay += 5; //다음날 처치해야할 몹 수 증가
            DayUp();
        }
    }

    private void DayUp()
    {
        day++;

        level = (day - 1) / 10; //10일마다 레벨업

        UIManager.Instance.UpdateDayUI(day);

        Debug.Log(day + (" ") + level);
    }
}
