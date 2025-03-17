using UnityEngine;
using TMPro; // Para manejar TextMeshPro

public class ThrowObject : MonoBehaviour
{
    public GameObject distractionPrefab; // Prefab del objeto que se lanza
    public Transform throwPoint; // Lugar desde donde se lanza
    public float throwForce = 10f; // Fuerza del lanzamiento
    public GameObject throwMessage; // Referencia al mensaje de UI

    private bool canThrow = true; // Para controlar si el jugador puede lanzar

    void Start()
    {
        if (throwMessage != null)
        {
            throwMessage.SetActive(false); // Ocultar mensaje al inicio
        }
    }

    void Update()
    {
        // Mostrar el mensaje cuando el jugador pueda lanzar una distracción
        if (canThrow && throwMessage != null)
        {
            throwMessage.SetActive(true);
        }
        else if (throwMessage != null)
        {
            throwMessage.SetActive(false);
        }

        // Si el jugador presiona G y puede lanzar
        if (canThrow && Input.GetKeyDown(KeyCode.G))
        {
            ThrowDistraction();
        }
    }

    void ThrowDistraction()
    {
        if (distractionPrefab != null)
        {
            GameObject distraction = Instantiate(distractionPrefab, throwPoint.position, Quaternion.identity);
            Rigidbody rb = distraction.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
            }
        }

        canThrow = false; // Evitar que el jugador lance sin límites
        if (throwMessage != null)
        {
            throwMessage.SetActive(false); // Ocultar el mensaje después de lanzar
        }

        // Opcional: Agregar un tiempo de espera antes de volver a lanzar
        Invoke(nameof(ResetThrow), 3f);
    }

    void ResetThrow()
    {
        canThrow = true;
    }
}
