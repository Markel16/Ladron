using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float walkSpeed = 3f; // Velocidad normal
    public float sprintSpeed = 6f; // Velocidad al correr
    private float currentSpeed; // Velocidad actual
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed; // Empezar con velocidad normal
    }

    void Update()
    {
        // Detectar si el jugador presiona Shift para correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed; // Duplicar velocidad
        }
        else
        {
            currentSpeed = walkSpeed; // Volver a velocidad normal
        }

        // Obtener entrada de movimiento (WASD)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Aplicar movimiento en función de la velocidad actual
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * currentSpeed * Time.deltaTime);
    }
}
