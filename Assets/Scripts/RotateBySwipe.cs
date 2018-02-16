using UnityEngine;
using System.Collections;

public class RotateBySwipe : MonoBehaviour
{
    [SerializeField]
    private Vector3 angles;
    private Vector2 start;

    private float xMultiplier, yMultiplier;
    private float x, y, z;
    private Vector3 newRot;
    private float speed;

    void Start()
    {
        xMultiplier = 360f / Screen.width;
        yMultiplier = 360f / Screen.height;
        speed = 5f;
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                start = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                newRot += new Vector3(touch.position.y - start.y, touch.position.x - start.x);

                start = touch.position;
            }
        }

        x = Mathf.Lerp(x, newRot.x, speed * Time.deltaTime);
        y = Mathf.Lerp(y, newRot.y, speed * Time.deltaTime);
        z = Mathf.Lerp(z, newRot.z, speed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(-new Vector3(x * angles.x * yMultiplier, y * angles.y * xMultiplier, z * angles.z));
    }
}
