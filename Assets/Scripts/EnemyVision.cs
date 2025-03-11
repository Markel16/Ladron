using UnityEngine;
using UnityEngine.AI; // Asegúrate de importar esto si usas NavMesh

public class EnemyVision : MonoBehaviour
{
    public float visionRange = 10f; // Distancia de visión
    public float visionAngle = 45f; // Ángulo del cono de visión
    public Transform player; // Referencia al jugador
    private NavMeshAgent agent; // Para moverse hacia el jugador

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Obtener el NavMeshAgent
    }

    void Update()
    {
        // Calcular dirección hacia el jugador
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Comprobar si el jugador está dentro del rango
        if (Vector3.Distance(transform.position, player.position) < visionRange)
        {
            // Comprobar si el jugador está dentro del ángulo de visión
            float angle = Vector3.Angle(transform.forward, directionToPlayer);
            if (angle < visionAngle)
            {
                // Lanzar un Raycast para asegurarse de que no hay obstáculos en el camino
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToPlayer, out hit, visionRange))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.Log("¡Jugador detectado! Persiguiéndolo...");
                        agent.SetDestination(player.position); // El enemigo se mueve hacia el jugador

                        // Reproducir sonido de alerta
                        GetComponent<EnemySound>().PlayAlertSound();
                    }
                }
            }
        }
    }
}


