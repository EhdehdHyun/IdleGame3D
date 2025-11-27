using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    private NavMeshAgent agent;
    private Player playerStats;

    [Header("Attack Settings")]
    public float attackRange = 2f;
    public float attackCooldown = 1f;

    private Transform currentTarget;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerStats = GetComponent<Player>();
    }

    private void Update()
    {
        if (currentTarget != null && !currentTarget.gameObject.activeSelf)
        {
            currentTarget = null;
        }

        attackCooldown -= Time.deltaTime;

        if (currentTarget == null)
            FindTarget();

        if (currentTarget == null)
            return;

        float distance = Vector3.Distance(transform.position, currentTarget.position);

        if (distance > attackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(currentTarget.position);
        }
        else
        {
            agent.isStopped = true;
            TryAttack();
        }
    }

    void TryAttack()
    {
        if (attackCooldown > 0f) return;

        attackCooldown = 1f / playerStats.attackSpeed;

        ZombieAI zombieAI = currentTarget.GetComponent<ZombieAI>();
        if (zombieAI != null)
        {
            zombieAI.TakeDamage(playerStats.power);
        }
    }

    void FindTarget()
    {
        float minDist = Mathf.Infinity;
        Transform nearestZombie = null;

        foreach (var zombie in ZombieManager.Instance.SpawnedZombies)
        {
            if (zombie == null || !zombie.activeSelf)
                continue;

            float dist = Vector3.Distance(transform.position, zombie.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearestZombie = zombie.transform;
            }
        }

        currentTarget = nearestZombie;
    }
}
