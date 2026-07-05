using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private float MovementSpeed = 5f;
    [SerializeField] private InputAction MoveAction;
    private Rigidbody PlayerRB;
    private Vector2 MoveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();

        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput = MoveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        float horizontalInput = MoveInput.x;
        float verticalInput = MoveInput.y;

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        PlayerRB.AddForce(moveDirection * MovementSpeed);
    }
}
