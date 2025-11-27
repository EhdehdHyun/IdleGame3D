using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
  public float health => CharacterManager.Instance.playerData.GetStat(StatType.Health);
  public float power => CharacterManager.Instance.playerData.GetStat(StatType.Power);
  public float attackSpeed => CharacterManager.Instance.playerData.GetStat(StatType.AttackSpeed);
  public float moveSpeed => CharacterManager.Instance.playerData.GetStat(StatType.MoveSpeed);



  private void Awake()
  {
    CharacterManager.Instance.player = this;
  }
}
