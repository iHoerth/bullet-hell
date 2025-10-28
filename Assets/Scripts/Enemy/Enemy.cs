using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public GameObject player;
    private Rigidbody rb;
    
    public float speed = 5f;
    public int damage;
    public int health;

    void Awake()
    {
        health = 20;
        damage = 5;
    }

    void Start()
    {   
        // Since the enemy is a prefab, the player has to be searched in runtime as follows
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        if (player == null) return;
        // use rigidbody to move enemy to player
        Vector3 dir = (player.transform.position - transform.position).normalized;
        // rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        rb.linearVelocity = dir * speed;
        transform.LookAt(player.transform.position);
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

    void Die()
    {
        // Animacion de muerte
        // Sonido de muerte
        Destroy(gameObject);
    }
}
