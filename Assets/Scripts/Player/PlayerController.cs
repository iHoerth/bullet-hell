using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public GameObject player; => esto no es necesario por q el script ESTA ATACHEADO al Player, entonces ya puede acceder a transform y demas cosas.
    public InputSystem_Actions playerActions;
    private CharacterController controller;
    public float speed;

    public GameObject bulletPrefab;

    // 1
    void Awake()
    {
        playerActions = new InputSystem_Actions();
        controller = GetComponent<CharacterController>();
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

        // pasar el moveDirection() al CC
        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    void Look()
    {
        Vector2 mousePos = playerActions.Player.Look.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            // Debug.Log("IMPACTO POINTO :" + hit.point);
            Vector3 lookPoint = hit.point;
            lookPoint.y = transform.position.y;
            transform.LookAt(lookPoint);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        }
        
    }

    void Shoot()
    {   
        GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Physics.IgnoreCollision(bulletInstance.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void DodgeRoll()
    {
        Debug.Log("Dodge Roll!");
    }
}
