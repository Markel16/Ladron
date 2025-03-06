using UnityEngine;

public class ZonaDeDeteccion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Estoy detectado");
        }
    }
}
