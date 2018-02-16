using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Swipe : MonoBehaviour {

    //setup variable
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;
    //public Text DebugText;

    private void Update()
    {
        /*tap = false;*/
        swipeLeft = false;
        swipeRight = false;
        swipeUp = false;
        swipeDown = false;

        //DebugText.text = "startTouchX:" + startTouch.x + " startTouchY:" + startTouch.y+"  swipeDeltaX:"+swipeDelta.x+ " swipeDeltaY:" + swipeDelta.y;

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended|| Input.touches[0].position.x<50)
            {
                Reset();
                swipeLeft = false;
                swipeRight = false;
                swipeUp = false;
                swipeDown = false;
            }
        }


        //calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = (Vector2)Input.touches[0].position - startTouch;
        }

        //is cross the dead zone?
        if (swipeDelta.magnitude > 125)
        {
            //check direction
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            //DebugText.text = "startTouchX:" + startTouch.x + " startTouchY:" + startTouch.y + "  swipeDeltaX:" + swipeDelta.x + " swipeDeltaY:" + swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or right
                if (x < 0)
                    swipeLeft = true;
                if(x>=0)
                    swipeRight = true;
            }
            else
            {
                //up or down
                if (y < 0)
                    swipeDown = true;
                if (y >= 0)
                    swipeUp = true;
            }

            //Reset();
        }
    }

    private void Reset()
    {
        startTouch = Vector2.zero;
        swipeDelta = Vector2.zero;
        isDraging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
}
