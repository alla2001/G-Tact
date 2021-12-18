using UnityEngine;
using UnityEngine.Events;

/*
 * Swipe Input script for Unity by @fonserbc, free to use wherever
 *
 * Attack to a gameObject, check the static booleans to check if a swipe has been detected this frame
 * Eg: if (SwipeInput.swipedRight) ...
 *
 *
 */

public class SwipeInput : MonoBehaviour
{
    // If the touch is longer than MAX_SWIPE_TIME, we dont consider it a swipe
    public const float MAX_SWIPE_TIME = 0.5f;

    // Factor of the screen width that we consider a swipe
    // 0.17 works well for portrait mode 16:9 phone
    public const float MIN_SWIPE_DISTANCE = 0.17f;

    public static bool swipedRight = false;
    public static bool swipedLeft = false;
    public static bool swipedUp = false;
    public static bool swipedDown = false;

    public bool debugWithArrowKeys = true;

    public Vector2 startPos;
    public Vector2 endPos;
    private float startTime;
    public UnityAction Swiped;
    public float SwipedDistance;
    public bool startedClicking;

    public void Update()
    {
        swipedRight = false;
        swipedLeft = false;
        swipedUp = false;
        swipedDown = false;
        //swipe input
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
                startTime = Time.time;
            }
            if (t.phase == TouchPhase.Ended)
            {
                if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
                    return;

                Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
                this.endPos = endPos;
                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
                SwipedDistance = swipe.magnitude;
                if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
                    return;

                if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                { // Horizontal swipe
                    if (swipe.x > 0)
                    {
                        swipedRight = true;
                        Swiped.Invoke();
                    }
                    else
                    {
                        swipedLeft = true;
                        Swiped.Invoke();
                    }
                }
                else
                { // Vertical swipe
                    if (swipe.y > 0)
                    {
                        swipedUp = true;
                        Swiped.Invoke();
                    }
                    else
                    {
                        swipedDown = true;
                        Swiped.Invoke();
                    }
                }
            }
        }
        else
        {
        }

        //mouse input
        if (Input.GetMouseButton(0))
        {
            if (!startedClicking)
            {
                startPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                startTime = Time.time;
                startedClicking = true;
            }
        }
        else
        {
            if (startedClicking)
            {
                Vector2 endPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                this.endPos = endPos;
                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
                SwipedDistance = swipe.magnitude;

                if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                { // Horizontal swipe
                    if (swipe.x > 0)
                    {
                        swipedRight = true;
                        Swiped.Invoke();
                    }
                    else
                    {
                        swipedLeft = true;
                        Swiped.Invoke();
                    }
                }
                else
                { // Vertical swipe
                    if (swipe.y > 0)
                    {
                        swipedUp = true;
                        Swiped.Invoke();
                    }
                    else
                    {
                        swipedDown = true;
                        Swiped.Invoke();
                    }
                }
            }

            startedClicking = false;
        }

        if (debugWithArrowKeys)
        {
            swipedDown = swipedDown || Input.GetKeyDown(KeyCode.DownArrow);
            swipedUp = swipedUp || Input.GetKeyDown(KeyCode.UpArrow);
            swipedRight = swipedRight || Input.GetKeyDown(KeyCode.RightArrow);
            swipedLeft = swipedLeft || Input.GetKeyDown(KeyCode.LeftArrow);
        }
    }
}