using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public ZombieStats stats;

    private NavMeshAgent agent;
    private Transform player;

    private float currentHealth;
    public float attackCooldown = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        agent.speed = stats.moveSpeed;
        currentHealth = stats.maxHealth;
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);

            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= 1f)
            {
                TryAttack();
            }
        }
    }

    void TryAttack()
    {
        attackCooldown -= Time.deltaTime;
        if (attackCooldown > 0f) return;

        attackCooldown = 1f / stats.attackSpeed; //공격속도 반영

        player.GetComponent<Player>().TakeDamage(stats.power);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        int finalGold = Mathf.RoundToInt(stats.goldReward * BuffManager.Instance.GetGoldMultiplier());

        UpgradeManager.Instance.gold += finalGold;

        UIManager.Instance.UpdateUpgradeUI();

        GameManager.Instance.OnKillEnemy();

        Destroy(gameObject);
    }
}
