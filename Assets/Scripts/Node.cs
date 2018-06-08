using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public 	Color hoverColor;
	public 	Color noMoneyColor;
	public Vector3 positionOffSet;

    [HideInInspector]
	public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
	private Color startColor;

	BuildManager buildManager;

	void Start(){

		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + positionOffSet;		
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject ())
			return;	
		
		if (turret!= null) 
		{
            buildManager.SelectNode(this);
			return;
		}

        if (!buildManager.CanBuild)
            return;

        //buildManager.BuildTurretOn (this);
        BuildTurret(buildManager.GetTurretTobuild());

	}

    void BuildTurret (TurretBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money.");
            //node.rend.material.color = Color.red;
            return;

        }
        PlayerStats.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;

        GameObject buildFX = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildFX, 5f);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade.");
            //node.rend.material.color = Color.red;
            return;

        }
        PlayerStats.Money -= turretBlueprint.upgradeCost;

        //Destroy old turret
        Destroy(turret);

        //build new
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject buildFX = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(buildFX, 5f);

        isUpgraded = true;
    }

    public void Sellturret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        //spawn effect
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject ())
			return;			

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney) {
			rend.material.color = hoverColor;			
		} else {
			rend.material.color = noMoneyColor;			
		}

	}
	void OnMouseExit(){
		rend.material.color = startColor;
	}
}
