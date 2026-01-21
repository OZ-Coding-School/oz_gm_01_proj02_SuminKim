using UnityEngine;

public class TowerUpgradeUI : MonoBehaviour
{
    private Tower selectedTower;

    public void SetSelectedTower(Tower tower)
    {
        selectedTower = tower;
    }

    public void OnUpgradeButtonClicked(TowerUpgradeData upgrade)
    {
        if (selectedTower == null)
        return;

        var controller = selectedTower.GetComponent<TowerUpgradeController>();
        if (controller == null)
        return;

        if (!controller.CanUpgrade(upgrade.path))
        return;

        if(GameManager.Instance.money < upgrade.cost)
        return;

        GameManager.Instance.AddMoney(-upgrade.cost);
        controller.ApplyUpgrade(upgrade);
    }
}
