using System.Collections.Generic;
using UnityEngine;

public class obstacleSpawnerEnter : MonoBehaviour
{
    public ObstacleSpawner obstacleSpawner; // Reference to the ObstacleSpawner
    public Transform[] spawnPoint; // The specific spawn point to add back
    public GameObject ose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] obstaclePrefab;
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
        availableSpawnPoints = new List<Transform>(spawnPoint);
    }

    void SpawnObstacle(int i)
    {
        // Check if there are available spawn points
        if (availableSpawnPoints.Count > 0)
        {
            // Select a random spawn point from the available list
            selectedSpawnPoint = availableSpawnPoints[i];
            randomIndex2 = Random.Range(0, obstaclePrefab.Length);
            selectedObstacle = obstaclePrefab[randomIndex2];
            string obstacleName = selectedSpawnPoint.ToString();


            // Spawn the obstacle at the selected spawn point
            GameObject obstacle = Instantiate(selectedObstacle, spawnPoint[i].position, Quaternion.identity);
            obstacle.name = "obstacleRoad" + obstacleName.Substring(0, 8);

            // Remove the selected spawn point from the available list
            availableSpawnPoints.RemoveAt(i);

            ObstacleController obstacleController = obstacle.GetComponent<ObstacleController>();
            if (obstacleController != null)
            {
                obstacleController.onDestroyCallback = () => ReturnSpawnPoint(selectedSpawnPoint);
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

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            if (ose.gameObject.name == "Spawner0")
            {
                int i = 0;
                SpawnObstacle(i);
            }
            else if (ose.gameObject.name == "Spawner1")
            {
                int i = 1;
                SpawnObstacle(i);
            }
            else if (ose.gameObject.name == "Spawner2")
            {
                int i = 2;
                SpawnObstacle(i);
            }
            else if (ose.gameObject.name == "Spawner3")
            {
                int i = 3;
                SpawnObstacle(i);
            }
            else if (ose.gameObject.name == "Spawner4")
            {
                int i = 4;
                SpawnObstacle(i);
            }
        }
    }
}
