using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	//public GameObject stanrdardTurretPrefab;
	//public GameObject missileTurretPrefab;
    //public GameObject laserTurretPrefab;
	public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBluePrint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

	void Awake ()
	{
		if (instance != null) 
		{
			Debug.LogError ("More than one BuildManager in scene");	
		}
		instance = this;

	}

	public bool CanBuild{ get { return turretToBuild != null; }	}

	public bool HasMoney{ get { return PlayerStats.Money >= turretToBuild.cost; }	}

	public void BuildTurretOn(Node node)
	{
		
	}
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselecteNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);
    }
    public void DeselecteNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
	{
		turretToBuild = turret;
        DeselecteNode();
	}
    public TurretBluePrint GetTurretTobuild()
    {
        return turretToBuild;
    }

}

//public void SetTurretToBuild (GameObject turret){
//turretToBuild = turret;
//}

//public GameObject GetturretToBuild()
//{
//return turretToBuild;
//}