using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float mouseSensitivity = 200f;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro

        // Asegurar que la cámara está correctamente en la cabeza del jugador
        if (player != null)
        {
            transform.SetParent(player); // La cámara sigue al jugador
            transform.localPosition = new Vector3(0, 0, 0); // Altura de la cabeza
        }
        else
        {
            Debug.LogError("Player no asignado en FirstPersonCamera.cs");
        }
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitar la rotación vertical

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
