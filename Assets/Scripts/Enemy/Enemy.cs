using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public GameObject player;
    private PlayerController playerController;
    private Rigidbody rb;
    
    public float speed = 5f;
    public int damage;
    public int health;
    public float attackRange = 3f;

    void Awake()
    {
        health = 20;
        damage = 5;
    }

    void Start()
    {   
        // Since the enemy is a prefab, the player has to be searched in runtime as follows
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        if (player == null) return;
        Vector3 target = new Vector3(player.transform.position.x, transform.position.y , player.transform.position.z);
        Vector3 dir = (target - transform.position).normalized;

        transform.LookAt(target);
        transform.position += dir * speed * Time.deltaTime;

        // Attack
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance <= attackRange)
        {
            playerController.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {   
        if(health > damage)
        {
            health -= damage;
        } 
        else 
        {
            health = 0;
            Die();
        }
    }

    public void Attack()
    {   
        // Vector3.distance returns a float with the distance between two R3 points (pythagoras)
    }

    void Die()
    {
        // Animacion de muerte
        // Sonido de muerte
        Destroy(gameObject);
    }
}
