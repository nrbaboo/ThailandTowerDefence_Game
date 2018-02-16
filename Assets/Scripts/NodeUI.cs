using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {

	public GameObject ui;
    public GameObject rangeUi;
    public Text upgradeCost;
	public Button upgradeButton;
    
	public Text sellAmount;

	private Node target;

	public void SetTarget (Node _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();
        int rangeTarget = 0;
        Color rangeColor = Color.blue; 
        if (!target.isUpgraded)
		{
			upgradeCost.text = target.turretBlueprint.upgradeCost + " บาท";
            rangeTarget = target.turretBlueprint.range;

            upgradeButton.interactable = true;
		} else
		{
			upgradeCost.text = "DONE";
			upgradeButton.interactable = false;
            rangeTarget = target.turretBlueprint.upgradedRange;
            rangeColor = Color.red;
        }

        rangeUi.transform.localScale = new Vector3(rangeTarget*2, rangeTarget * 2, rangeTarget * 2);
     
        sellAmount.text = target.turretBlueprint.GetSellAmount() + " บาท";

		ui.SetActive(true);
        rangeUi.SetActive(true);
    }

	public void Hide ()
	{
		ui.SetActive(false);
        rangeUi.SetActive(false);

    }

	public void Upgrade ()
	{
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}

	public void Sell ()
	{
		target.SellTurret();
		BuildManager.instance.DeselectNode();
	}

}
