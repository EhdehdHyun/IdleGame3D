using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemButton : MonoBehaviour
{
    public ItemShop item;
    public Button buyButton;
    void Start()
    {
        buyButton.onClick.AddListener(OnBuy);
    }

    void OnBuy()
    {
        if (UpgradeManager.Instance.gold < item.cost)
        {
            Debug.Log("골드 부족");
            return;
        }

        UpgradeManager.Instance.gold -= item.cost;

        switch (item.itemType)
        {
            case ShopItemType.Heal:
                CharacterManager.Instance.player.Heal(item.healAmount);
                break;
            case ShopItemType.PowerBoost:
                break;
            case ShopItemType.GoldBoost:
                break;
        }
        UIManager.Instance.UpdateUpgradeUI(); //골드수치가 변경됐으니 최신화
    }
}
