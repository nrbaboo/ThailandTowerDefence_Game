using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TurretSpawner : MonoBehaviour {

    public GameObject turret;
    void Start()
    {
        string t = PlayerPrefs.GetString("TURRET_KEY");

        GameObject prefab = Resources.Load("getTurret/" + t, typeof(GameObject)) as GameObject;
        turret = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        turret.transform.SetParent(transform);
        turret.transform.localRotation = Quaternion.Euler(90f, 180f, 0f);
        turret.transform.localPosition = new Vector3(0f, 0f, -10f);

        PlayerPrefs.DeleteKey("TURRET_KEY");
    }

    public GameObject getTurret()
    {
        return turret;
    }

    public void Run()
    {
        SceneManager.LoadScene("map");
    }
}
