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
        //Si se va usar una funnción que se requiera pasar el nombre de otra como string, usar "nameof" esto transforma el nombre de la función en dicho tipo
        //y es code-safe ya que si se cambia el nombre de la función referenciada no causa que esta se pierda.
        InvokeRepeating(nameof(SpawnSpiders), 1f, spawnInterval);
    }


    void SpawnSpiders()
    {
        if (currentSpiders >= maxSpiders) return;
        Instantiate(spiderPrefab, spiderSpawn.position, Quaternion.identity);
        currentSpiders++;

    }

}
