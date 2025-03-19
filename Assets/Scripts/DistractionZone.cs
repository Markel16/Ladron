using UnityEngine;

public class DistractionZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Distraction")) // Si la distracción cae en el suelo
        {
            GameObject distraction = other.gameObject;
            Collider distractionCollider = distraction.GetComponent<Collider>();

            if (distractionCollider != null)
            {
                distractionCollider.enabled = false; // Evita que siga activando el trigger
            }

            // Encuentra todos los enemigos y los distrae
            EnemyVision[] enemies = FindObjectsOfType<EnemyVision>();
            foreach (EnemyVision enemy in enemies)
            {
                enemy.Distract(distraction.transform.position);
            }

            Destroy(distraction, 0.5f); // Elimina la distracción después de activarse
        }
    }
}
