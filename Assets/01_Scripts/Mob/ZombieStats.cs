using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieStats", menuName = "ScriptableObjects/ZombieStats")]
public class ZombieStats : ScriptableObject
{
    [Header("기본 스탯")]
    public StatType mainStat;
    public GameObject prefab;

    [Header("스탯 정보")]
    public float maxHealth;
    public float moveSpeed;
    public float attackSpeed;
    public float power;

    [Header("보상")]
    public int goldReward = 10;

    [Header("unlockLevel")]
    public int unlockLevel = 0;
}
