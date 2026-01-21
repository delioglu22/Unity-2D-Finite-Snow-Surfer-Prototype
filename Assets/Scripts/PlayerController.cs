using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 3f;
    InputAction moveAction;
    Rigidbody2D rb;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveVector;
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x > 0)
            rb.AddTorque(-torqueAmount);
        else if (moveVector.x < 0)
            rb.AddTorque(torqueAmount);
    }
}
