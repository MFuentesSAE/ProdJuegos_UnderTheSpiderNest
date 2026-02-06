using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spiderPrefab;
    public Transform spiderSpawn;
    public float spawnInterval = 3f;
    int maxSpiders = 10;
    int currentSpiders;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnSpiders), 1f, spawnInterval);
    }


    void SpawnSpiders()
    {
        if (currentSpiders >= maxSpiders) return;
        Instantiate(spiderPrefab, spiderSpawn.position, Quaternion.identity);
        currentSpiders++;

    }

}
