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

    [Header("Day and Kill UI")]
    public TMP_Text dayText;
    public TMP_Text killText;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        powerBtn.onClick.AddListener(() => UpgradeManager.Instance.UpgradeStat(StatType.Power));
        healthBtn.onClick.AddListener(() => UpgradeManager.Instance.UpgradeStat(StatType.Health));
        speedBtn.onClick.AddListener(() => UpgradeManager.Instance.UpgradeStat(StatType.MoveSpeed));
        attackSpeedBtn.onClick.AddListener(() => UpgradeManager.Instance.UpgradeStat(StatType.AttackSpeed));

        dayText.text = $"Day: {GameManager.Instance.day}";
        UpdateKillCountUI();
    }

    public void UpdateUpgradeUI()
    {
        goldText.text = $"Gold: {UpgradeManager.Instance.gold}";
        nextCoastText.text = $"Next Cost: {UpgradeManager.Instance.upgradeCoast}";

        var data = CharacterManager.Instance.playerData;
        powerText.text = CharacterManager.Instance.playerData.GetStat(StatType.Power).ToString();
        healthText.text = CharacterManager.Instance.playerData.GetStat(StatType.Health).ToString();
        speedText.text = CharacterManager.Instance.playerData.GetStat(StatType.MoveSpeed).ToString();
        attackSpeedText.text = CharacterManager.Instance.playerData.GetStat(StatType.AttackSpeed).ToString();
    }

    public void UpdateDayUI(int day)
    {
        dayText.text = $"Day: {day}";
    }

    public void UpdateKillCountUI()
    {
        killText.text = ($"{GameManager.Instance.killCount} / {GameManager.Instance.killPerDay}");
    }
}
