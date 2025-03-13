using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    public float visionRange = 10f; // Distancia de visión
    public float visionAngle = 45f; // Ángulo del cono de visión
    public Transform player; // Referencia al jugador
    private NavMeshAgent agent; // Para moverse
    public Transform[] patrolPoints; // Puntos de patrulla
    private int currentPatrolIndex = 0;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        PatrolToNextPoint(); // Empezar la patrulla
    }

    void Update()
    {
        if (!isChasing)
        {
            // Si llega al destino, ir al siguiente punto
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                PatrolToNextPoint();
            }
        }

        DetectPlayer(); // Comprobar si el jugador está en rango
    }

    void PatrolToNextPoint()
    {
        if (patrolPoints.Length == 0) return;

        // Mover al siguiente punto de patrulla
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);

        // Cambiar al siguiente punto de la lista
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    void DetectPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        if (Vector3.Distance(transform.position, player.position) < visionRange)
        {
            float angle = Vector3.Angle(transform.forward, directionToPlayer);
            if (angle < visionAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToPlayer, out hit, visionRange))
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.Log("¡Jugador detectado! Persiguiéndolo...");
                        isChasing = true;
                        agent.SetDestination(player.position);
                        GetComponent<EnemySound>().PlayAlertSound();
                    }
                }
            }
        }
    }
}
