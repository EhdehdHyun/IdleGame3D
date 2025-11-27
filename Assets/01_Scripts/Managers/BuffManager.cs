using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public static BuffManager Instance;

    private int powerBonus = 0;
    private float GoldBoost = 1f;
    private void Awake()
    {
        Instance = this;
    }

    public void ApplyPowerBuff(int bonus, float duration)
    {
        StopCoroutine("PowerBufferRountine");
        StartCoroutine(PowerBufferRoutine(bonus, duration));
    }

    IEnumerator PowerBufferRoutine(int bonus, float duration)
    {
        powerBonus += bonus;

        yield return new WaitForSeconds(duration);

        powerBonus = 0;
    }

    public float GetPowerBonus() => powerBonus;

    public void ApplyGoldBoost(float multiplier, float duration)
    {
        StopCoroutine("GoldBoostRoutine");
        StartCoroutine(GoldBoostRoutine(multiplier, duration));
    }

    IEnumerator GoldBoostRoutine(float multiplier, float duration)
    {
        GoldBoost = multiplier;
        yield return new WaitForSeconds(duration);
        GoldBoost = 1f;
    }

    public float GetGoldMultiplier() => GoldBoost;
}
