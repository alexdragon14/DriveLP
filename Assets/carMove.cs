using UnityEngine;

public class carMove : MonoBehaviour
{
    // Speed at which the car will move upward
    public float speed = 1f;

    void Update()
    {
        // Move the car upward automatically
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
