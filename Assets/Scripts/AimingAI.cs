using UnityEngine;
using UnityEngine.AI;

public class AimingAI : MonoBehaviour
{
    public Transform target;  // Drag your target GameObject here
    public bool canShot;
    public float distanceFollow;
    public float distanceShot;
    public float shotTimer;
    public WeaponLukas weapon;
    private NavMeshAgent agent;
    private float timer;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (target != null && Vector3.Distance(transform.position,target.position) < distanceFollow) 
        {
            float yPos = transform.position.y;

            // Calculate the direction from agent to target
            Vector3 directionToTarget = target.position - transform.position;

            // Create the rotation to look at the target
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x,yPos, directionToTarget.z));

            // Apply the rotation to the agent's transform
            transform.rotation = targetRotation;

            if (canShot && Vector3.Distance(transform.position, target.position) < distanceShot)
            {
                agent.ResetPath();

                if (timer >= shotTimer)
                {
                    weapon.Fire(new Vector2(target.position.x,target.position.z));
                    AudioManager.Instance.EnemyShot(transform.position);
                    timer = 0;
                }
                return;
            }

            // Set the agent's destination to the target position
            agent.SetDestination(target.position);
        }
    }
}