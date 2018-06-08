using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

    public GameObject ui;

    public Text upgradeCost;
    public Button upgradedButton;

    public Text SellCost;    

    private Node target;

    public void SetTarget (Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradedButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Max Upgraded!";
            upgradedButton.interactable = false;
        }

        SellCost.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselecteNode();
    }
    public void Sell()
    {
        target.Sellturret();
        BuildManager.instance.DeselecteNode();
    }

}
