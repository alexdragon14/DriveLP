using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Action onDestroyCallback; // Callback for when the obstacle is destroyed

    void OnDestroy()
    {
        // Invoke the callback when the obstacle is destroyed
        onDestroyCallback?.Invoke();
    }
}
