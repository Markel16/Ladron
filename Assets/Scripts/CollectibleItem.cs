using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Sumar el objeto al contador del jugador
            GameManager.instance.CollectItem();
            Debug.Log("¡Objeto recogido!");

            // Destruir el objeto al recogerlo
            Destroy(gameObject);
        }
    }
}

