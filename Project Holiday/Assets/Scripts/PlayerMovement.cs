using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;

    [Header("Movement variables")] private float playerSpeed;
    [SerializeField] private float playerWalkSpeed = 0.1f;

    [SerializeField] private float playerRunSpeed = 0.2f;

    void Start() {
        rb = GetComponent<Rigidbody>();
        playerSpeed = playerWalkSpeed;
    }

    void Update() {
        CheckInput();
        MovePlayer();
    }

    void CheckInput() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            playerSpeed = playerRunSpeed;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)) {
            playerSpeed = playerWalkSpeed;
        }
    }

    void MovePlayer() {
        
        rb.MovePosition(transform.position + Vector3.Normalize(movement) * playerSpeed);
    }
}
