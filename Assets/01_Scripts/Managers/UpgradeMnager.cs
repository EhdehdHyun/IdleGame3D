using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMnager : MonoBehaviour
{
    public static UpgradeMnager Instance;

    public int gold = 999999;
    public int upgradeCoast = 100;

    public float increaseAmount = -1f; //스탯 증가량(스탯마다 다르게 설정 예정)

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void UpgradeStat(StatType statType)
    {
        if (gold < upgradeCoast) return;

        gold -= upgradeCoast;

        float current = CharacterManager.Instance.playerData.GetStat(statType);
        CharacterManager.Instance.playerData.SetStat(statType, current + increaseAmount);

        upgradeCoast = Mathf.RoundToInt(upgradeCoast * 1.5f);

        UIManager.Instance.UpdateUpgradeUI();
    }
}
