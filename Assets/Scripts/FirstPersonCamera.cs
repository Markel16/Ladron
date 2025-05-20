using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float sprintSpeed = 6f;
    private float currentSpeed;
    private CharacterController controller;
    public float mouseSensitivity = 200f;

    public float pushForce = 5f;  // Fuerza con la que empuja objetos

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
        if (controller != null)
        {
            controller.Move(move * currentSpeed * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // Usar tag "Empujar" en lugar de layer
        if (body != null && body.CompareTag("Empujar"))
        {
            Vector3 force = hit.moveDirection * pushForce;
            body.AddForce(force, ForceMode.Impulse);
        }
    }
}


