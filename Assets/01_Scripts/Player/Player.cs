using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
  public float health => CharacterManager.Instance.playerData.GetStat(StatType.Health);
  public float currentHealth;
  public float power => CharacterManager.Instance.playerData.GetStat(StatType.Power);
  public float attackSpeed => CharacterManager.Instance.playerData.GetStat(StatType.AttackSpeed);
  public float moveSpeed => CharacterManager.Instance.playerData.GetStat(StatType.MoveSpeed);

  private void Start()
  {
    currentHealth = health;

    HPBarManager.Instance.UpdateHPBar(currentHealth, health);
  }

  private void Awake()
  {
    CharacterManager.Instance.player = this;
  }

  void Update()
  {
    HPBarManager.Instance.UpdateHPBar(currentHealth, health);
  }

  public void TakeDamage(float damage)
  {
    currentHealth -= damage;

    Debug.Log(currentHealth);

    HPBarManager.Instance.UpdateHPBar(currentHealth, health);

    if (currentHealth <= 0)
    {
      Die();
    }
  }

  public void ApplyStats()
  {
    var agent = GetComponent<NavMeshAgent>();
    if (agent != null)
    {
      agent.speed = moveSpeed;
    }
  }

  public void Heal(int Amount)
  {
    currentHealth += Amount;
    if (currentHealth > health)
    {
      currentHealth = health;
    }
  }

  void Die()
  {
    Debug.Log("Player Died");
  }
}
