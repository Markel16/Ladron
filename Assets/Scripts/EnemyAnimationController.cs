using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (animator == null)
        {
            Debug.LogWarning("No Animator found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (agent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("isWalking", true);  //Activar caminar
        }
        else
        {
            animator.SetBool("isWalking", false); //Parar animación
        }
    }
}
