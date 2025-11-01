using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public GameObject player;
    private PlayerController playerController;
    private Rigidbody rb;
    private Animator anim;


    public float baseSpeed;
    public float baseDamage;
    public float baseHealth;
    public float attackRange = 4f;
    public float attackTriggerRange = 3f;
    private bool isAttacking = false;

    float distanceToPlayer;

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
        if(distanceToPlayer <= attackTriggerRange)
        {   
            Attack();
        }
    }

    // This is called every frame in FixedUpdate
    void Move()
    {
        if (player == null) return;
        float speedWhileAttackingFactor = isAttacking ? 10f : 1f;
        // Get Player position. This logic could be in a helper GetTargetPosition() but not sure
        Vector3 target = new Vector3(player.transform.position.x, transform.position.y , player.transform.position.z);
        Vector3 dir = (target - transform.position).normalized;

        transform.LookAt(target);
        transform.position += (dir * baseSpeed * Time.deltaTime) / speedWhileAttackingFactor;
    }

    public void TakeDamage(float damage)
    {   
        if(baseHealth > damage)
        {

            baseHealth -= damage;
        } 
        else 
        {
            baseHealth = 0;
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
            playerController.TakeDamage(baseDamage);
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
