using UnityEngine;

public class SpawnedObject : MonoBehaviour
{
    private Transform spawnPoint;
    private SpawnManager spawnManager;

    public void Initialize(Transform spawnPoint, SpawnManager manager)
    {
        this.spawnPoint = spawnPoint;
        this.spawnManager = manager;
    }

    private void OnDestroy()
    {
        if (spawnManager != null)
        {
            spawnManager.RemoveObjectAtSpawnPoint(spawnPoint);
        }
    }
}
