using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float sprintSpeed = 6f;
    private float currentSpeed;
    private CharacterController controller;
    public float mouseSensitivity = 200f;

    public float pushForce = 5f;  // Fuerza con la que empuja objetos

    // 🔽 Gravedad manual
    public float gravity = -9.81f;
    public float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        //  Aplicar la gravedad manual
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; // para que le personaje este pegado al suelo
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        move.y = verticalVelocity; 

        if (controller != null)
        {
            controller.Move(move * currentSpeed * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // objetos que solo tiene que empujar
        if (body != null && body.gameObject.layer == LayerMask.NameToLayer("Empujar"))
        {
            Vector3 force = hit.moveDirection * pushForce;
            body.AddForce(force, ForceMode.Impulse);
        }
    }
}

