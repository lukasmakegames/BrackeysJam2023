using UnityEngine;
using UnityEngine.AI;

public class AimingAI : MonoBehaviour
{
    public Transform target;  // Drag your target GameObject here
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null && Vector3.Distance(transform.position,target.position)<10f) 
        {
            // Calculate the direction from agent to target
            Vector3 directionToTarget = target.position - transform.position;

            // Create the rotation to look at the target
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Apply the rotation to the agent's transform
            transform.rotation = targetRotation;

            // Set the agent's destination to the target position
            agent.SetDestination(target.position);
        }
    }
}