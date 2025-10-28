using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public GameObject player; => esto no es necesario por q el script ESTA ATACHEADO al Player, entonces ya puede acceder a transform y demas cosas.
    public InputSystem_Actions playerActions;
    private CharacterController controller;
    public float speed;

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
    }

    // 3
    void Start()
    {
        // Get character controller o cualquier componente que requiera (salvo el transform, ese puedo usarlo de 1)

    }

    // Update is called once per frame and after Awake() -> OnEnable() -> Start()
    void Update()
    {
        // leer input
        Vector2 input = playerActions.Player.Move.ReadValue<Vector2>();
        // convertir a v3
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);
        // pasar a moveDirection() del CC
        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    void OnDisable()
    {
        playerActions.Disable();
    }
}
