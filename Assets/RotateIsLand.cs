using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIsLand : MonoBehaviour {

    public GameObject PartToRotate;
    int time = 0,time2=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (time >= 100)
        {
            PartToRotate.transform.Rotate(Vector3.left * Time.deltaTime);
            time2++;
            if (time2 >= 100)
            {
                time = 0;
                time2 = 0;
            }
        }
        else
        {
            PartToRotate.transform.Rotate(Vector3.right * Time.deltaTime);
            time++;
        }
        Debug.Log(time);

    }
}
