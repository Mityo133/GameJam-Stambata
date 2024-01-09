using UnityEngine;

public class shit : MonoBehaviour
{
    public float speed = 2.0f;
    public float startDelay = 20.0f; // Delay before the object starts moving

    private bool canMove = false;
    private float moveTimer = 1.0f;

    void Start()
    {
        // Set up the delay
        moveTimer = -startDelay;
    }

    void Update()
    {
        // Increment the timer
        moveTimer += Time.deltaTime;

        // Check if the "E" key is pressed
        if (Input.GetKeyDown(KeyCode.E) && !canMove)
        {
            canMove = true; // Set to true to start movement
        }

        // Check if the delay time has passed and movement is allowed
        if (moveTimer >= 0 && canMove)
        {
            // Move the object down relative to its local orientation for 5 times
            for (int i = 0; i < 5; i++)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);

                // Wait for a short delay between movements
                if (i < 4)
                {
                    // Increase the timer to introduce a short delay between movements
                    moveTimer += 0.1f;
                    return;
                }
            }
        }
    }
}



