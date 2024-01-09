using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player; // Reference to the player GameObject
    public Vector3 offset = new Vector3(0f, 1.5f, 0f); // Adjust the camera position relative to the player
    public float sensitivity = 2f; // Mouse sensitivity

    private float rotationX = 0f;
    private float rotationY = 0f;

    void LateUpdate()
    {
        if (player != null)
        {
            // Rotate the player based on mouse input
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            rotationY += mouseX;

            transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0f);

            // Position the camera relative to the player
            transform.position = player.position + offset;
        }
    }
}
