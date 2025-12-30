using System.Collections;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the GameObject has a specific tag (optional)
        if (other.CompareTag("Car")) // Replace "Car" with your tag if needed
        {
            StartCoroutine(DoSomething(other));
            // Destroy the GameObject that entered the trigger
        }
    }

    IEnumerator DoSomething(Collider2D carobject)
    {
        yield return new WaitForSeconds(1);
        Destroy(carobject.gameObject);
    }
}
