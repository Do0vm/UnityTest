using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player;  // Reference to the player’s transform
    public float fixedYPosition = 0f;  // The fixed Y position you want for the camera

    void LateUpdate()
    {
        // Set the camera's X position to the player's X position, but keep Y locked
        transform.position = new Vector3(player.position.x, fixedYPosition, transform.position.z);
    }
}
