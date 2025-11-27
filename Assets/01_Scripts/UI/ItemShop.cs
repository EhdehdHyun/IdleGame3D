using UnityEngine;

public enum ShopItemType
{
    Heal,
    PowerBoost,
    GoldBoost
}

[CreateAssetMenu(fileName = "ShopItem", menuName = "IdleGame/ShopItem")]
public class ItemShop : ScriptableObject
{
    public string itemName;
    public int cost;
    public ShopItemType itemType;

    [Header("Item Effects")]
    public int healAmount;      // 회복
    public float powerMultiplier; // 힘증가 부스트
    public float goldMultiplier;  // 골드증가 부스트
    public float effectDuration;  // 지속시간
}
