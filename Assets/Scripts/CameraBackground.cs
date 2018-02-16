using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraBackground : MonoBehaviour {

    private RawImage image;
    private WebCamTexture cam;
    private AspectRatioFitter arf;

    // Use this for initialization
    void Start()
    {
        arf = GetComponent<AspectRatioFitter>();
        image = GetComponent<RawImage>();


        // Checks how many and which cameras are available on the device
        for (int cameraIndex = 0; cameraIndex < WebCamTexture.devices.Length; cameraIndex++)
        {
            // We want the back camera
            if (!WebCamTexture.devices[cameraIndex].isFrontFacing)
            {
                cam = new WebCamTexture(cameraIndex, Screen.width, Screen.height);

                // Here we flip the GuiTexture by applying a localScale transformation
                // works only in Landscape mode
                //image.transform.localScale = new Vector3(-1, -1, 1);
            }

        }

        // Here we tell that the texture of coming from the camera should be applied 
        // to our GUITexture. As we have flipped it before the camera preview will have the 
        // correct orientation
        image.texture = cam;
        // Starts the camera
        cam.Play();

    }

    // Update is called once per frame
    void Update () {
        if (cam.width < 100) {
            return;
        }

        float cwNeeded = -cam.videoRotationAngle;

        if (cam.videoVerticallyMirrored)
        {
            cwNeeded += 180f;
        }

        image.rectTransform.localEulerAngles = new Vector3(0f, 0f, cwNeeded);
        float videoRatio = (float)cam.width / (float)cam.height;
        arf.aspectRatio = videoRatio;

        if (cam.videoVerticallyMirrored)
        {
            image.uvRect = new Rect(1, 0, -1, 1);
        }
        else {
            image.uvRect = new Rect(0, 0, 1, 1);
        }
        
	}
}
