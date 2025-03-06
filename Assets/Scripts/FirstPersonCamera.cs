using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 200f; // Sensibilidad del mouse
    public Transform playerBody; // Referencia al cuerpo del jugador

    private float xRotation = 0f; // Para controlar la rotación vertical

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Ocultar y bloquear el cursor en el centro
    }

    void Update()
    {
        // Capturar movimiento del mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotar la cámara en el eje X (mirar arriba/abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar para evitar giro completo
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotar el cuerpo del jugador en el eje Y (girar a los lados)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
