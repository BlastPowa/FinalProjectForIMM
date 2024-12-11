using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;       // Array of obstacle prefabs
    public GameObject[] powerUps;        // Array of power-up prefabs
    public Transform[] spawnPoints;     // Array of spawn points
    public float spawnInterval = 5f;    // Time between spawns

    private Dictionary<Transform, GameObject> activeObjects = new Dictionary<Transform, GameObject>();

    void Start()
    {
        // Start the spawn cycle
        StartCoroutine(SpawnCycle());
    }

    IEnumerator SpawnCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Select a random spawn point
            Transform spawnPoint = GetRandomAvailableSpawnPoint();

            if (spawnPoint != null)
            {
                // Randomly decide whether to spawn an obstacle or a power-up
                bool spawnObstacle = Random.value > 0.5f;

                GameObject prefabToSpawn = spawnObstacle
                    ? obstacles[Random.Range(0, obstacles.Length)]
                    : powerUps[Random.Range(0, powerUps.Length)];

                // Spawn the object
                GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

                // Track the active object at this spawn point
                activeObjects[spawnPoint] = spawnedObject;

                // Add a destruction callback to clean up when the object is destroyed
                spawnedObject.AddComponent<SpawnedObject>().Initialize(spawnPoint, this);
            }
            else
            {
                Debug.Log("No available spawn points for this cycle.");
            }
        }
    }

    Transform GetRandomAvailableSpawnPoint()
    {
        List<Transform> availableSpawnPoints = new List<Transform>();

        foreach (Transform spawnPoint in spawnPoints)
        {
            if (!activeObjects.ContainsKey(spawnPoint) || activeObjects[spawnPoint] == null)
            {
                availableSpawnPoints.Add(spawnPoint);
            }
        }

        if (availableSpawnPoints.Count > 0)
        {
            return availableSpawnPoints[Random.Range(0, availableSpawnPoints.Count)];
        }

        return null;
    }

    public void RemoveObjectAtSpawnPoint(Transform spawnPoint)
    {
        if (activeObjects.ContainsKey(spawnPoint))
        {
            activeObjects.Remove(spawnPoint);
        }
    }
}
