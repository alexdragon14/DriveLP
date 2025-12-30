using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefab; 
    public GameObject carPrefab; // Assign your car prefab here
    public GameObject[] roadSign;
    public Transform[] spawnPoints; // Drag your spawn points in the Inspector
    public float spawnInterval = 0f; // Time between spawns

    private List<Transform> availableSpawnPoints;

    int randomIndex;
    Transform selectedSpawnPoint;
    int randomIndex2;
    GameObject selectedObstacle;
    GameObject selectedRoadSign;

    void Start()
    {
        // Initialize the list of available spawn points
        availableSpawnPoints = new List<Transform>(spawnPoints);

        // Start spawning cars at regular intervals
        InvokeRepeating(nameof(SpawnObstacle), spawnInterval, spawnInterval);
    }

    void SpawnObstacle()
    {
        // Check if there are available spawn points
        if (availableSpawnPoints.Count > 0)
        {
            // Select a random spawn point from the available list
            randomIndexSpawn();
            string obstacleName = selectedSpawnPoint.ToString();

            
                // Spawn the obstacle at the selected spawn point
                GameObject obstacle = Instantiate(selectedObstacle, selectedSpawnPoint.position, Quaternion.identity);
                obstacle.name = "obstacleRoad" + obstacleName.Substring(0, 8);

                // Remove the selected spawn point from the available list
                availableSpawnPoints.RemoveAt(randomIndex);

                ObstacleController obstacleController = obstacle.GetComponent<ObstacleController>();
                if (obstacleController != null)
                {
                    //StartCoroutine(DoSomething2(obstacleController, selectedSpawnPoint));
                }
            
        }
    }

    void randomIndexSpawn()
    {
        // Select a random spawn point from the available list
        randomIndex = Random.Range(0, availableSpawnPoints.Count);
        selectedSpawnPoint = availableSpawnPoints[randomIndex];
        randomIndex2 = Random.Range(0, obstaclePrefab.Length);
        selectedObstacle = obstaclePrefab[randomIndex2];
    }

    public void ReturnSpawnPoint(Transform spawnPoint)
    {
        // Add the spawn point back to the available list
        if (!availableSpawnPoints.Contains(spawnPoint))
        {
            availableSpawnPoints.Add(spawnPoint);
        }
    }


    IEnumerator DoSomething(Collider2D carobject)
    {
        yield return new WaitForSeconds(1);
        Destroy(carobject.gameObject);
    }

    IEnumerator DoSomething2(ObstacleController obstacleController, Transform selectedSpawnPoint)
    {
        yield return new WaitForSeconds(10);
        obstacleController.onDestroyCallback = () => ReturnSpawnPoint(selectedSpawnPoint);
    }

}
