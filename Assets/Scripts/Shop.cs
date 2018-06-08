using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBluePrint standardTurret;
	public TurretBluePrint missileLauncher;
    public TurretBluePrint laserBeamer;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret()
	{
		//Debug.Log ("Standard Turret Selected");
		buildManager.SelectTurretToBuild (standardTurret);
	}
	public void SelectMissileTurret()
	{
		//Debug.Log ("Another Turret Selected");
		buildManager.SelectTurretToBuild (missileLauncher);
	}
    public void SelectLaserTurret()
    {
        //Debug.Log ("LaseBeamer Turret Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }

}
