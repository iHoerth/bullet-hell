using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public GameObject player; => esto no es necesario por q el script ESTA ATACHEADO al Player, entonces ya puede acceder a transform y demas cosas.
    public InputSystem_Actions playerActions;
    private CharacterController controller;
    public float speed;

    public GameObject bullet;

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

    // 3
    void Start()
    {
    }

    // Update is called once per frame and after Awake() -> OnEnable() -> Start()
    void Update()
    {
        Move();
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

    void Shoot()
    {   
        Instantiate(bullet, transform.position, transform.rotation);
        Debug.Log("Bang bang!");
    }

    void DodgeRoll()
    {
        Debug.Log("Dodge Roll!");
    }
}
