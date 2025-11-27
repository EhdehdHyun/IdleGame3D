using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("텍스트 UI")]
    public TMP_Text goldText;
    public TMP_Text nextCoastText;

    [Header("스탯 UI")]
    public TMP_Text powerText;
    public TMP_Text healthText;
    public TMP_Text speedText;
    public TMP_Text attackSpeedText;

    [Header("버튼")]
    public Button powerBtn;
    public Button healthBtn;
    public Button speedBtn;
    public Button attackSpeedBtn;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        powerBtn.onClick.AddListener(() => UpgradeMnager.Instance.UpgradeStat(StatType.Power));
        healthBtn.onClick.AddListener(() => UpgradeMnager.Instance.UpgradeStat(StatType.Health));
        speedBtn.onClick.AddListener(() => UpgradeMnager.Instance.UpgradeStat(StatType.MoveSpeed));
        attackSpeedBtn.onClick.AddListener(() => UpgradeMnager.Instance.UpgradeStat(StatType.AttackSpeed));

        UpdateUpgradeUI();
    }

    public void UpdateUpgradeUI()
    {
        goldText.text = $"Gold: {UpgradeMnager.Instance.gold}";
        nextCoastText.text = $"Next Coast: {UpgradeMnager.Instance.upgradeCoast}";

        var data = CharacterManager.Instance.playerData;
        powerText.text = data.GetStat(StatType.Power).ToString("0");
        healthText.text = data.GetStat(StatType.Health).ToString("0");
        speedText.text = data.GetStat(StatType.MoveSpeed).ToString("0");
        attackSpeedText.text = data.GetStat(StatType.AttackSpeed).ToString("0");
    }
}
