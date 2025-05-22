using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player; 
    public float mouseSensitivity = 200f;

    [Header("Límites de cámara")]
    public float minVerticalAngle = -45f; // Límite hacia abajo
    public float maxVerticalAngle = 60f;  // Límite hacia arriba

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (player != null)
        {
            transform.SetParent(player);
            transform.localPosition = Vector3.zero;
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
        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle); 

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}

