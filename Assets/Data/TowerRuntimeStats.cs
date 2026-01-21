using UnityEngine;

[System.Serializable]
public class TowerRuntimeStats
{
    public float damage;
    public float range;
    public float fireRate;

    public bool hasSplash;
    public bool hasSlow;


    public void ApplyUpgrade(TowerUpgradeData upgrade)
    {
        damage += upgrade.damageBonus;
        range += upgrade.rangeBonus;
        fireRate *= upgrade.fireRateMultiplier;

        if (upgrade.addsSplash)
        {
            hasSplash = true;
        }

        if (upgrade.addsSlow)
        {
            hasSlow = true;
        }
    }
}