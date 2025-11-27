using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public int gold = 999999;
    public int upgradeCoast = 100;
    public float upgradeCostMultiplier = 1.2f;

    private float increaseAmount = -1f; //스탯 증가량(스탯마다 다르게 설정 예정)

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void UpgradeStat(StatType statType)
    {
        if (gold < upgradeCoast)
        {
            Debug.Log("골드가 부족합니다.");
            return;
        }

        gold -= upgradeCoast;

        float current = CharacterManager.Instance.playerData.GetStat(statType);
        GetIncreaseAmount(statType);

        CharacterManager.Instance.playerData.SetStat(statType, current + increaseAmount);

        if (statType == StatType.MoveSpeed)
        {
            var player = CharacterManager.Instance.player;
            var agent = player.GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.speed = player.moveSpeed;
        }

        upgradeCoast = Mathf.RoundToInt(upgradeCoast * upgradeCostMultiplier);

        UIManager.Instance.UpdateUpgradeUI();
    }

    private void GetIncreaseAmount(StatType statType)
    {
        switch (statType)
        {
            case StatType.Power:
                increaseAmount = 2f;
                break;
            case StatType.Health:
                increaseAmount = 20f;
                CharacterManager.Instance.player.currentHealth += increaseAmount;
                break;
            case StatType.AttackSpeed:
                increaseAmount = 0.1f;
                break;
            case StatType.MoveSpeed:
                increaseAmount = 0.5f;
                break;
        }
    }
}
