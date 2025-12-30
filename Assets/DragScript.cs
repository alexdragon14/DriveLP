using UnityEngine;

public class DragScript : MonoBehaviour
{
    // Variable to determine an offset between your finger touch
    // and a center of a game object so it will not jump to the touch position
    // when you move your finger for the first time
    float deltaX, deltaY;

    // Allows to move a game object if you touch it
    bool moveAllowed = false;

    // Allows to move only this particular game object
    // that you touched when touch began
    bool thisColTouched = false;

    // Reference to the game objects component
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint (touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        {
                            thisColTouched = true;
                            moveAllowed = true;

                            deltaX = touchPos.x - transform.position.x;
                            deltaY = touchPos.y - transform.position.y;
                        }
                        break;
                    }
                case TouchPhase.Moved:
                    {
                        if (GetComponent<Collider2D>() == Physics2D.OverlapPoint (touchPos) && moveAllowed && thisColTouched)
                        {
                            rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                        }
                        break;
                    }
                case TouchPhase.Ended:
                    {
                        moveAllowed = false;
                        thisColTouched = false;
                        break;
                    }
            }
        }
    }

}
