using UnityEngine;

public class Distraction : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) // Si el enemigo detecta la distracción
        {
            EnemyVision enemyVision = other.GetComponent<EnemyVision>();
            if (enemyVision != null)
            {
                enemyVision.InvestigatePoint(transform.position);
            }
            Destroy(gameObject, 0.5f); // Destruir el objeto tras la distracción
        }
    }
}
