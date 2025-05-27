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
        float speed = agent.velocity.magnitude;

        
        if (speed > 0.1f && speed < 3f)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isSprinting", false);
        }
        
        else if (speed >= 3f)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isSprinting", true);
        }
        
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isSprinting", false);
        }
    }
}
