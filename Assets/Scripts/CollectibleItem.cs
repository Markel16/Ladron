using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public AudioClip pickupSound; // Sonido de recolección

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reproducir sonido al recoger
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            // Sumar el objeto al contador del jugador
            GameManager.instance.CollectItem();
            Debug.Log("¡Objeto recogido!");

            // Destruir el objeto al recogerlo
            Destroy(gameObject);
        }
    }
}
