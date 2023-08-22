using UnityEngine;

public class Door : MonoBehaviour
{

    public float movementSpeed = 1.0f; // Adjust the movement speed
    public float distanceToMove = 1.0f; // Adjust the distance to move

    private float initialYPosition;
    private bool open = false;

    public void OpenDoor()
    {

        initialYPosition = transform.position.y;
        open = true;
    }

    void Update()
    {
        if (open)
        {
            // Calculate the new Y position
            float newYPosition = initialYPosition + distanceToMove;

            // Move the GameObject upwards using Time.deltaTime for smooth movement
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);

            // Check if the desired distance has been covered
            if (transform.position.y >= newYPosition)
            {
                // Stop the movement or perform any necessary actions
                open = false;
            }
        }
    }
}
