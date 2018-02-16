using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeMenuManager : MonoBehaviour {

    private int menu_position;
    private int mune_velocity;
    public GameObject menu;

	// Use this for initialization
	void Start () {
        menu_position = 1000;
        mune_velocity = 10;
        menu.transform.position += new Vector3(0, 1000, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (menu_position>0) {
            menu.transform.position -= new Vector3(0, mune_velocity, 0);
            menu_position-= mune_velocity;
        }    
	}
}
