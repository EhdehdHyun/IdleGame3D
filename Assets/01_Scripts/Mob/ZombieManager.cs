using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{
    public static ZombieManager Instance;

    [Header("스폰 설정")]
    public float spawnRadius = 20f;
    public float timer;

    public int maxZombies = 30;

    [Header("레벨별 스폰 데이터")]
    public List<ZombieSpawnSet> zombieSpawnSets = new List<ZombieSpawnSet>();

    private List<GameObject> spawnedZombies = new List<GameObject>();
    public IReadOnlyList<GameObject> SpawnedZombies => spawnedZombies;

    private Transform player;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (player == null)
            Debug.LogError("❌ ZombieManager: Player 태그를 가진 오브젝트를 찾지 못했습니다!");

        if (zombieSpawnSets.Count == 0)
            Debug.LogError("❌ ZombieManager: zombieSpawnSets 가 비어 있습니다! 스폰셋을 등록하세요.");

        Debug.Log("✔ ZombieManager Start() 완료");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRadius)
        {
            timer = 0f;
            TrySpawn();
        }
    }

    void TrySpawn()
    {
        spawnedZombies.RemoveAll(z => z == null || !z.activeSelf);
        if (spawnedZombies.Count >= maxZombies) return;

        int level = GameManager.Instance.level;
        int index = Mathf.Min(level, zombieSpawnSets.Count - 1);

        ZombieStats chosenStats = ChooseRandomZombie(zombieSpawnSets[index]);
        if (chosenStats == null) return;

        if (TryGetRandomPosition(out Vector3 pos))
        {
            GameObject zombie = Instantiate(chosenStats.prefab, pos, Quaternion.identity);
            zombie.GetComponent<ZombieAI>().stats = chosenStats;
            spawnedZombies.Add(zombie);
        }


    }

    ZombieStats ChooseRandomZombie(ZombieSpawnSet set)
    {
        int total = 0;
        foreach (var entry in set.spawnEntries)
            total += entry.weight;

        int rand = Random.Range(0, total);

        foreach (var entry in set.spawnEntries)
        {
            if (rand < entry.weight)
                return entry.zombieStats;
            rand -= entry.weight;
        }
        return null;
    }

    bool TryGetRandomPosition(out Vector3 result)
    {
        for (int i = 0; i < 25; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * 20;
            randomOffset.y = 1;

            Vector3 testPos = player.position + randomOffset;

            if (NavMesh.SamplePosition(testPos, out NavMeshHit hit, 4f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }

        result = Vector3.zero;
        return false;
    }
}
