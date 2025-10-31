using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // public GameObject player; => esto no es necesario por q el script ESTA ATACHEADO al Player, entonces ya puede acceder a transform y demas cosas.
    public InputSystem_Actions playerActions;
    private CharacterController controller;
    private Animator anim;

    public float speed;

    public Bullet bulletPrefab;

    public int damage = 10;
    public int health = 100;
    public float invulnerabilityDuration = 1f;
    public float invulnerabilityTimer = 0f;
    public float shootCooldown = 0.5f;
    public float shootTimer = 0f;
    private bool isAttacking = false;
    // 1
    void Awake()
    {
        playerActions = new InputSystem_Actions();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // 2
    void OnEnable()
    {
        playerActions.Enable();
        playerActions.Player.Attack.performed += ctx => Shoot();
        playerActions.Player.Dodge.performed += ctx => DodgeRoll();
    }

    // Update is called once per frame and after Awake() -> OnEnable() -> Start()
    void Update()
    {
        Move();
        Look();

        if (invulnerabilityTimer > 0)
            invulnerabilityTimer -= Time.deltaTime;

        if (shootTimer > 0)
            shootTimer -= Time.deltaTime;        
    }

    void OnDisable()
    {
        playerActions.Disable();
    }

    void Move()
    {   
        // leer inputs y convertir a v3
        Vector2 input = playerActions.Player.Move.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);

        // pasar el m;oveDirection() al CC
        controller.Move(moveDirection * speed * Time.deltaTime);
        // Magnitud del vector (0 a 1 según el input del gamepad/teclado)
        float moveMagnitude = moveDirection.magnitude;

        // Actualizar parámetro del Animator
        anim.SetFloat("MoveSpeed", moveMagnitude);
    }

    void Look()
    {
        // Get mouse position
        Vector2 mousePos = playerActions.Player.Look.ReadValue<Vector2>();
        // Cast ray to mouse pos
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            // Store hit point in a new variable
            Vector3 lookPoint = hit.point;
            // Adjust "y" to match player height, otherwise it is at 0 (plane is at y = 0)
            lookPoint.y = transform.position.y;
            transform.LookAt(lookPoint);
        }
        
    }

    public void Shoot()
    {   
        if (shootTimer > 0) return;
        Debug.Log("Shoot");

        anim.SetBool("isAttacking", true);
        isAttacking = true;
        // Adjust bullet positio nto avoid collision with plane floor
        Vector3 spawnPos = transform.position + transform.forward * 0.5f + Vector3.up * 1.5f;

        // Create bullet prefab instance when Shoot is called
        Bullet bulletInstance = Instantiate(bulletPrefab, spawnPos, transform.rotation);

        bulletInstance.damage = damage;
        // Ignore collision between player and bullet instance to avoid bullet insta disappearing
        Physics.IgnoreCollision(bulletInstance.GetComponent<Collider>(), controller.GetComponent<Collider>());

        shootTimer = shootCooldown;
    }

    public void FinishShoot()
    {
        anim.SetBool("isAttacking", false);
        isAttacking = false;        
    }

    public void TakeDamage(int damage)
    {
        if(invulnerabilityTimer > 0) return;

        if(health > damage)
        {
            health -= damage;
            invulnerabilityTimer = invulnerabilityDuration;
        } 
        
        else 
        {
            health = 0;
            Die();
        }

    }

    void DodgeRoll()
    {   
        // Placeholder before real implementation
        Debug.Log("Dodge Roll!");
    }

    void Die()
    {
        Debug.Log("u ded");
    }
}
