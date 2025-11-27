using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieSpawnSet", menuName = "ScriptableObjects/ZombieSpawnSet")]
public class ZombieSpawnSet : ScriptableObject
{
    [System.Serializable]
    public class SpawnEntry
    {
        public ZombieStats zombieStats;
        public int weight;
    }

    public List<SpawnEntry> spawnEntries = new List<SpawnEntry>();
}
