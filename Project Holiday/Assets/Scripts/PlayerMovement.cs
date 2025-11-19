using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private Animator animator;

    [Header("Movement variables")] private float playerSpeed;
    [SerializeField] private float playerWalkSpeed = 0.1f;

    [SerializeField] private float playerRunSpeed = 0.2f;

    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        if (animator == null) {
            Debug.LogError("Animator cannot be found");
        }
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
        rb.linearVelocity = movement.normalized;
        Debug.Log("RB linear velocity: " + rb.linearVelocity.magnitude);
        animator.SetFloat("PlayerVelocity", rb.linearVelocity.magnitude);
    }

    void Animations() {
        
    }
}
