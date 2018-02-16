using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroCamera : MonoBehaviour {
    private Gyroscope gyro;
    private bool gyroSupport;
    private Quaternion rotfix;

    [SerializeField]
    private Transform wouldObj;
    private float startY;

	// Use this for initialization
	void Start () {
        Screen.orientation = ScreenOrientation.Portrait;

        gyroSupport = SystemInfo.supportsGyroscope;

        GameObject canParent = new GameObject("canParent");
        canParent.transform.position = transform.position;
        transform.parent = canParent.transform;

        if (gyroSupport) {
            gyro = Input.gyro;
            gyro.enabled = true;

            canParent.transform.rotation = Quaternion.Euler(90f, 180f, 0f);
            rotfix = new Quaternion(0, 0, 1, 0);
        }
        gyro = Input.gyro;
	}
	
	// Update is called once per frame
	void Update () {

        if (gyroSupport && startY == 0) {
            resetGyroRotation();
        }

        transform.localRotation = gyro.attitude * rotfix;
	}

    void resetGyroRotation() {
        startY = transform.eulerAngles.y;
        wouldObj.rotation = Quaternion.Euler(0f, startY, 0f);
    }
}
