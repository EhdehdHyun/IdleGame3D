using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerStat
{
    public StatType statType;
    public float value;
}

[System.Serializable]
public class PlayerData
{
    public List<PlayerStat> stats = new List<PlayerStat>();

    public float lastSaveTime;
    public int level;
    public float exp;

    public float GetStat(StatType type)
    {
        foreach (var s in stats)
        {
            if (s.statType == type)
            {
                return s.value;
            }
        }

        return 0f;
    }

    public void SetStat(StatType type, float value)
    {
        foreach (var s in stats)
        {
            if (s.statType == type)
            {
                s.value = value;
                return;
            }
        }

        stats.Add(new PlayerStat { statType = type, value = value }); //없다면
    }
}
