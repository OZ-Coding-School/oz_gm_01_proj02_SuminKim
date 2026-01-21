using UnityEngine;

public class TowerUpgradeController : MonoBehaviour
{
    public int pathA = 0;
    public int pathB = 0;

    public int maxTier = 4;

    public bool CanUpgrade(UpgradePath path)
    {
        if (path == UpgradePath.PathA)
        {
            if (pathA >= maxTier) return false;
            if (pathB >= 3 && pathA >= 2) return false;
        }
        else
        {
            if (pathB >= maxTier) return false;
            if (pathA >= 3 && pathB >= 2) return false;
        }

        return true;
    }

    public void ApplyUpgrade(TowerUpgradeData upgrade)
    {
        if (!CanUpgrade(upgrade.path))
        return;

        if (upgrade.path == UpgradePath.PathA)
        {
            pathA++;
        }
        else
        {
            pathB++;
        }

        ApplyStats(upgrade);
    }

    void Applystats(TowerUpgradeData upgrade)
    {
        Tower tower = GetComponent<Tower>();

        tower.runtimeStats.damage += upgrade.damageBonus;
        tower.runtimeStats.range += upgrade.rangeBonus;
        tower.runtimeStats.fireRate *= upgrade.fireRateMultiplier;

        if (upgrade.addsSplash)
        {
            tower.EnableSplash();
        }

        if (upgrade.addsSlow)
        {
            tower.EnableSlow();
        }
    }
}
