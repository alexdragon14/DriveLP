using UnityEngine;

public class roadSignSpawner : MonoBehaviour
{
    public GameObject[] roadSign;
    private Collider2D currentSpawnZone;
    public GameObject sideBarClose;
    public GameObject player;
    public Rigidbody2D rb;

    void Start()
    {
        player = GetComponent<GameObject>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void SpawnObject()
    {
        if (currentSpawnZone != null)
        {
            string spawnName;
            int roadSignNo = 0;
            // Spawn the object on top of the collider
            Vector3 spawnPosition = currentSpawnZone.transform.position;
            spawnPosition.z = 0; // Adjust to place on top
            spawnName = currentSpawnZone.ToString();
            GameObject roadSignSpawn = Instantiate(roadSign[roadSignNo], spawnPosition, Quaternion.identity);
            roadSignSpawn.name = "road" + spawnName.Substring(0,10);
        }
    }

    public void SpawnObject1()
    {
        if (currentSpawnZone != null)
        {
            string spawnName;
            int roadSignNo = 1;
            // Spawn the object on top of the collider
            Vector3 spawnPosition = currentSpawnZone.transform.position;
            spawnPosition.z = 0; // Adjust to place on top
            spawnName = currentSpawnZone.ToString();
            GameObject roadSignSpawn = Instantiate(roadSign[roadSignNo], spawnPosition, Quaternion.identity);
            roadSignSpawn.name = "road" + spawnName.Substring(0, 10);
        }
    }

    public void SpawnObject2()
    {
        if (currentSpawnZone != null)
        {
            string spawnName;
            int roadSignNo = 2;
            // Spawn the object on top of the collider
            Vector3 spawnPosition = currentSpawnZone.transform.position;
            spawnPosition.z = 0; // Adjust to place on top
            spawnName = currentSpawnZone.ToString();
            GameObject roadSignSpawn = Instantiate(roadSign[roadSignNo], spawnPosition, Quaternion.identity);
            roadSignSpawn.name = "road" + spawnName.Substring(0, 10);
        }
    }

    public void SpawnObject3()
    {
        if (currentSpawnZone != null)
        {
            string spawnName;
            int roadSignNo = 3;
            // Spawn the object on top of the collider
            Vector3 spawnPosition = currentSpawnZone.transform.position;
            spawnPosition.z = 0; // Adjust to place on top
            spawnName = currentSpawnZone.ToString();
            GameObject roadSignSpawn = Instantiate(roadSign[roadSignNo], spawnPosition, Quaternion.identity);
            roadSignSpawn.name = "road" + spawnName.Substring(0, 10);
        }
    }

    public void SpawnObject4()
    {
        if (currentSpawnZone != null)
        {
            string spawnName;
            int roadSignNo = 4;
            // Spawn the object on top of the collider
            Vector3 spawnPosition = currentSpawnZone.transform.position;
            spawnPosition.z = 0; // Adjust to place on top
            spawnName = currentSpawnZone.ToString();
            GameObject roadSignSpawn = Instantiate(roadSign[roadSignNo], spawnPosition, Quaternion.identity);
            roadSignSpawn.name = "road" + spawnName.Substring(0, 10);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if we entered a spawn zone
        if (other.CompareTag("RoadSignZone"))
        {
            sideBarClose.SetActive(false);
            currentSpawnZone = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Check if we left the spawn zone
        if (other.CompareTag("RoadSignZone"))
        {
            sideBarClose.SetActive(true);
            currentSpawnZone = null;
        }
    }


}
