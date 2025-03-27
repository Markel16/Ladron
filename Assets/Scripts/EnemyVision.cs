using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyVision : MonoBehaviour
{
    public float visionRange = 10f;
    public float visionAngle = 45f;
    public Transform player;

    private NavMeshAgent agent;
    public Transform[] patrolPoints;
    private int currentPatrolIndex = 0;

    private bool isChasing = false;
    private bool isDistracted = false;
    private float chaseTimer = 0f;

    public float patrolSpeed = 2f;
    public float chaseSpeed = 5f;
    public float chaseTime = 5f;

    // ALERTA VISUAL
    public Image alertImage;
    private float alertDuration = 1f;
    private float alertTimer = 0f;

    // 🟢 NUEVO: Referencia directa al script de la UI
    private DetectionFlashUI flashUI;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;
        PatrolToNextPoint();

        if (alertImage != null)
        {
            alertImage.enabled = false;
        }

        // 🟢 NUEVO: Buscar el script de la alerta al inicio
        flashUI = FindObjectOfType<DetectionFlashUI>();
    }

    void Update()
    {
        if (isDistracted) return;

        if (!isChasing && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            PatrolToNextPoint();
        }

        DetectPlayer();

        if (alertImage != null && alertImage.enabled)
        {
            alertTimer -= Time.deltaTime;
            if (alertTimer <= 0f)
            {
                alertImage.enabled = false;
            }
        }
    }

    void PatrolToNextPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
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

                        // 🔴 Mostrar flash visual desde el script DetectionFlashUI
                        if (flashUI != null)
                        {
                            flashUI.ShowFlash();
                        }

                        if (alertImage != null)
                        {
                            alertImage.enabled = true;
                            alertTimer = alertDuration;
                        }

                        isChasing = true;
                        isDistracted = false;
                        agent.speed = chaseSpeed;
                        agent.SetDestination(player.position);
                        GetComponent<EnemySound>()?.PlayAlertSound();
                        chaseTimer = chaseTime;
                    }
                }
            }
        }

        if (isChasing)
        {
            chaseTimer -= Time.deltaTime;
            if (chaseTimer <= 0f)
            {
                Debug.Log("Jugador perdido. Volviendo a patrullar.");
                isChasing = false;
                agent.speed = patrolSpeed;
                PatrolToNextPoint();
            }
        }
    }

    public void Distract(Vector3 distractionPoint)
    {
        if (!isChasing)
        {
            Debug.Log("El enemigo ha oído un ruido. Investigando...");
            isDistracted = true;
            agent.speed = patrolSpeed;
            agent.SetDestination(distractionPoint);

            Invoke(nameof(ResumePatrol), 5f);
        }
    }

    void ResumePatrol()
    {
        Debug.Log("El enemigo deja de estar distraído, vuelve a patrullar.");
        isDistracted = false;
        PatrolToNextPoint();
    }
}
