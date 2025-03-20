using UnityEngine;

public class SafeInteraction : MonoBehaviour
{
    public GameObject safeCanvas; // Referencia al Canvas de la caja fuerte
    private bool isNearSafe = false;

    void Update()
    {
        if (isNearSafe && Input.GetKeyDown(KeyCode.E)) // Si está cerca y presiona "E"
        {
            safeCanvas.SetActive(true); // Muestra el minijuego
            Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
            Cursor.visible = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador está cerca
        {
            isNearSafe = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador se aleja
        {
            isNearSafe = false;
            safeCanvas.SetActive(false); // Oculta el minijuego
            Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor nuevamente
            Cursor.visible = false;
        }
    }
}
