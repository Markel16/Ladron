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
    public float patrolSpeed = 2f; // Velocidad cuando patrulla
    public float chaseSpeed = 5f; // Velocidad cuando persigue al jugador
    public float chaseTime = 5f; // Tiempo que busca al jugador antes de volver a patrullar
    private float chaseTimer = 0f; // Contador para la persecución


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;
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
                        agent.speed = chaseSpeed; // Cambia la velocidad al modo persecución
                        agent.SetDestination(player.position);
                        GetComponent<EnemySound>().PlayAlertSound();
                        chaseTimer = chaseTime; // Reinicia el tiempo de persecución
                    }
                }
            }
        }

        // Si está persiguiendo pero pierde de vista al jugador
        if (isChasing)
        {
            chaseTimer -= Time.deltaTime;
            if (chaseTimer <= 0f)
            {
                Debug.Log("Jugador perdido. Volviendo a patrullar.");
                isChasing = false;
                agent.speed = patrolSpeed; // Vuelve a la velocidad de patrulla
                PatrolToNextPoint(); // Reinicia la patrulla
            }
        }
    }

}
