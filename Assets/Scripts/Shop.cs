using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurret;
	public TurretBlueprint missileLauncher;
	public TurretBlueprint laserBeamer;
    public TurretBlueprint extraTurret1;
    public Text DebugText;
    static public bool haveExtraTurret1 = false;
    static public bool haveExtraTurret2 = false;
    static public bool haveExtraTurret3 = false;
    static public bool haveExtraTurret4 = false;
    static public bool haveExtraTurret5 = false;
    static public bool haveExtraTurret6 = false;
    BuildManager buildManager;

	void Start ()
	{
		buildManager = BuildManager.instance;

    }
   
	public void SelectStandardTurret ()
	{
		Debug.Log("Standard Turret Selected");
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void SelectMissileLauncher()
	{
		Debug.Log("Missile Launcher Selected");
		buildManager.SelectTurretToBuild(missileLauncher);
	}

	public void SelectLaserBeamer()
	{
		Debug.Log("Laser Beamer Selected");
		buildManager.SelectTurretToBuild(laserBeamer);
	}
    public void SelectExtraTurret1()
    {
        if (!haveExtraTurret1)
            return;
        DebugText.text = "Extra Turret Selected";
        buildManager.SelectTurretToBuild(extraTurret1);
    }

}
