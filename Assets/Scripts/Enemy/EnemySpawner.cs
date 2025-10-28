using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;

    private Vector3 spawnOffset;

    private float timeCounter = 0f;
    public float spawnTime = 5f;
    public float spawnRadius = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter >= spawnTime)
        {
            SpawnEnemy();
            timeCounter = 0f;
        }


    }

    public void SpawnEnemy()
    {   
        spawnOffset = new Vector3(Random.Range(-spawnRadius, spawnRadius), 0f, Random.Range(-spawnRadius, spawnRadius));
        Vector3 spawnPos = player.transform.position + spawnOffset;
        Quaternion spawnRotation = Quaternion.LookRotation(player.transform.position - spawnPos);

        Instantiate(enemyPrefab, spawnPos,spawnRotation);
    }
}
