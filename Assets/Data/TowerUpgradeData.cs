using UnityEngine;
[CreateAssetMenu(menuName = "BTD/TowerUpgrade")]
public class TowerUpgradeData : ScriptableObject
{
    public UpgradePath path;
    public int tier;

    public int cost;

    [Header("Stat Changes")]
    public float damageBonus;
    public float rangeBonus;
    public float fireRateMultiplier = 1f;

    [Header("Special")]
    public bool addsSplash;
    public bool addsSlow;
}
