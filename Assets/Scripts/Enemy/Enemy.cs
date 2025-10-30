using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public GameObject player;
    private PlayerController playerController;
    private Rigidbody rb;
    private Animator anim;


    public float speed = 5f;
    public int damage;
    private bool isAttacking = false;
    public int health;
    public float attackRange = 3f;

    float distanceToPlayer;

    // Called once to initialize some variables
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
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Move();
        // Calculate distanceToPlayer to player
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= attackRange)
        {   
            Attack();
        }
    }

    // This is called every frame in FixedUpdate
    void Move()
    {
        if (player == null) return;
        speed = isAttacking? 1f : 5f;

        // Get Player position. This logic could be in a helper GetTargetPosition() but not sure
        Vector3 target = new Vector3(player.transform.position.x, transform.position.y , player.transform.position.z);
        Vector3 dir = (target - transform.position).normalized;

        transform.LookAt(target);
        transform.position += dir * speed * Time.deltaTime;
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

    // This gets called by FixedUpdate, which cheks every frame for the distance to the player. If less than attackRadius, Attack is called.
    public void Attack()
    {   
        anim.SetBool("isAttacking", true);
        isAttacking = true;
    }
    
    // This gets called by the Animator Event DealDamage, in the exact frame where the weapon impacts
    public void DealDamage()
    {
        if(distanceToPlayer <= attackRange)
        {
            playerController.TakeDamage(damage);
        }
    }

    // This gets called by the Animator Event "EndAttack"
    public void EndAttack()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }

    void Die()
    {
        // death animation ???
        // death sound?????
        Destroy(gameObject);
    }
}
