using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Dictionary<StatType, float> stats;

    public float lastSaveTime;
    public int level;
    public float exp;
}
