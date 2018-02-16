using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

	public float panSpeed = 30f;
	public float panBorderThickness = 10f;
    public float angle = 65f;

    //swipe controller
    public Swipe swipeController;

	public float scrollSpeed = 1f;
	public float minY = 10f;
	public float maxY = 80f;

    public Canvas canvasStoryHero;  // ลาก storyHeroCanvas มาใส่
    void Start()
    {
        canvasStoryHero.enabled = false;
        WaveSpawner.EnemiesAlive = 0;
    }

    // Update is called once per frame
    void Update () {

		if (GameManager.GameIsOver)
		{
			this.enabled = false;
			return;
		}


        if (swipeController.SwipeUp)
		{
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
		}
		if (swipeController.SwipeDown)
		{
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
        if (swipeController.SwipeLeft)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (swipeController.SwipeRight)
		{
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
		}

        #region zoom_mobile
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            Vector3 pos = transform.position;

            pos.y += deltaMagnitudeDiff * 1 * scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            transform.position = pos;
        }
        #endregion


        /*#region zoom_mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");

		Vector3 pos2 = transform.position;

		pos2.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
		pos2.y = Mathf.Clamp(pos2.y, minY, maxY);

		transform.position = pos2;
        #endregion*/

        transform.rotation = Quaternion.Euler(angle, 0, 0);
    }

    public void AdjustAngle(Slider valueFromSlice)
    {
        angle = valueFromSlice.value;
    }
}
