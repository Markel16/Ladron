using UnityEngine;
using TMPro; // Necesario para manejar TextMeshPro

public class CollectibleItem : MonoBehaviour
{
    private bool isInRange = false; // Saber si el jugador está cerca
    public KeyCode pickUpKey = KeyCode.E; // Tecla para recoger el objeto
    public GameObject interactMessage; // Referencia al mensaje UI

    void Start()
    {
        if (interactMessage != null)
        {
            interactMessage.SetActive(false); // Ocultar mensaje al inicio
        }
    }

    void Update()
    {
        // Si el jugador está en rango y presiona la tecla, recoge el objeto
        if (isInRange && Input.GetKeyDown(pickUpKey))
        {
            PickUp();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true; // El jugador está en rango
            if (interactMessage != null)
            {
                interactMessage.SetActive(true); // Mostrar mensaje
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false; // El jugador salió del rango
            if (interactMessage != null)
            {
                interactMessage.SetActive(false); // Ocultar mensaje
            }
        }
    }

    void PickUp()
    {
        Debug.Log("Objeto recogido: " + gameObject.name);
        if (interactMessage != null)
        {
            interactMessage.SetActive(false); // Ocultar mensaje tras recoger
        }
        Destroy(gameObject); // Elimina el objeto tras recogerlo
    }
}
