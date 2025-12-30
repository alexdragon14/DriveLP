using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab; // Assign your car prefab here
    public Transform[] spawnPoints; // Drag your spawn points in the Inspector
    public float spawnInterval = 2f; // Time between spawns
    public int spawnCount = 12;

    private List<Transform> availableSpawnPoints;

    void Start()
    {
        // Initialize the list of available spawn points
        availableSpawnPoints = new List<Transform>(spawnPoints);

        // Start spawning cars at regular intervals
        InvokeRepeating(nameof(SpawnCar), spawnInterval, spawnInterval);
    }

    void SpawnCar()
    {
        // Check if there are available spawn points
        if (spawnCount > 0)
        {
            // Select a random spawn point from the available list
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform selectedSpawnPoint = availableSpawnPoints[randomIndex];

            // Spawn the car at the selected spawn point
            GameObject car = Instantiate(carPrefab, selectedSpawnPoint.position, Quaternion.identity);
            car.name = "car" + selectedSpawnPoint.name.Substring(0,8);

            // Remove the selected spawn point from the available list
            availableSpawnPoints.RemoveAt(randomIndex);
            StartCoroutine(DoSomething(selectedSpawnPoint));
            

            // Add a callback to return the spawn point when the car is destroyed
            CarController carController = car.GetComponent<CarController>();
            spawnCount--;
        }

    }


    void ReturnSpawnPoint(Transform spawnPoint)
    {
        // Add the spawn point back to the available list
        if (!availableSpawnPoints.Contains(spawnPoint))
        {
            availableSpawnPoints.Add(spawnPoint);
        }
    }

    IEnumerator DoSomething(Transform selectedSpawnPoint)
    {
        yield return new WaitForSeconds(18);
        ReturnSpawnPoint(selectedSpawnPoint);
    }
}
