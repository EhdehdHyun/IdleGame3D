using UnityEngine;
using UnityEngine.UI;

public class HPBarManager : MonoBehaviour
{
    public static HPBarManager Instance;

    [Header("HP Fill Image")]
    public Image hpFillImage;

    private void Awake()
    {
        Instance = this;
    }


    public void UpdateHPBar(float currentHP, float maxHP)
    {
        float fillAmount = currentHP / maxHP;
        hpFillImage.fillAmount = fillAmount;
    }
}
