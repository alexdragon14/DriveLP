using UnityEngine;

public class movableObject : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!gameManager.Instance.isGameStarted)
        {
            rb.linearVelocity = Vector3.zero; // Stop the object from moving
            rb.angularVelocity = Vector3.zero; // Stop rotation
            return;
        }

        // Movement logic (e.g., for player or AI)
        float move = Input.GetAxis("Vertical") * 5f;
        rb.linearVelocity = new Vector3(move, rb.linearVelocity.y, rb.linearVelocity.z);
    }
}
