using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public GameObject player;

    private Vector3 spawnDirection;

    private float timeCounter = 0f;
    public float spawnTime = 2.5f;
    public float spawnDistance = 35f;

    public float difficulty = 1f; 
    public float baseSpeed = 8f;
    public float baseDamage = 10f;
    public float baseHealth = 20;

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter >= spawnTime)
        {
            SpawnEnemy();
            SpawnEnemy();
            timeCounter = 0f;
        }
    }

    public void SpawnEnemy()
    {   
        // Generate a random versor in the radius 1 circle, centered at 0,0.
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        // Convert to Vector3
        spawnDirection = new Vector3(randomDir.x, 0f, randomDir.y);
        // Move center to player and escalate
        Vector3 spawnPos = player.transform.position + spawnDirection * spawnDistance;
        spawnPos.y = 0;
        // Adjust rotation to make it look the player
        Quaternion spawnRotation = Quaternion.LookRotation(player.transform.position - spawnPos);

        Enemy newEnemy = Instantiate(enemyPrefab, spawnPos,spawnRotation);

        // Make enemies scale based on difficulty
        float speed = baseSpeed * Mathf.Pow(1.25f, difficulty - 1);  // multiplicative 20% each difficulty level
        float damage = baseDamage * Mathf.Pow(1.5f, difficulty - 1); // multiplicative 50% each difficulty level
        float health = this.baseHealth;

        newEnemy.baseDamage = damage;
        newEnemy.baseSpeed = speed;
        newEnemy.baseHealth = health;
    }
}
