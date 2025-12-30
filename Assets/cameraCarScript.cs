using UnityEngine;

public class cameraCarScript : MonoBehaviour
{
    public Transform target; // Assign the object to follow in the Inspector
    public float offsetY = 5f; // Adjust the vertical offset if needed

    private float fixedX; // Store the camera's initial x-position
    private float fixedZ; // Store the camera's initial z-position

    void Start()
    {
        // Save the initial x and z positions of the camera
        fixedX = transform.position.x;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Follow the target's y position, keep x and z fixed
            transform.position = new Vector3(fixedX, target.position.y + offsetY, fixedZ);
        }
    }
}
