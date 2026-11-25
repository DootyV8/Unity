using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float viewDistance = 15f;
    public float wanderRadius = 10f;
    public float wanderTimer = 4f;

    private Transform player;
    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        timer = wanderTimer;
    }

    void Update()
    {
        if (player != null && CanSeePlayer())
        {
            agent.SetDestination(player.position);
            timer = wanderTimer;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= wanderTimer || agent.remainingDistance <= agent.stoppingDistance)
            {
                Vector3 newPos = RandomNavMeshPoint(transform.position, wanderRadius);
                agent.SetDestination(newPos);
                timer = 0f;
            }
        }
    }

    bool CanSeePlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > viewDistance) return false;

        Vector3 eyePos = transform.position + Vector3.up * 0.5f;
        Vector3 targetPos = player.position + Vector3.up * 0.5f;

        if (Physics.Linecast(eyePos, targetPos, out RaycastHit hit))
        {
            return hit.transform == player || hit.transform.IsChildOf(player);
        }

        return true;
    }

    Vector3 RandomNavMeshPoint(Vector3 origin, float dist)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist + origin;
        if (NavMesh.SamplePosition(randDirection, out NavMeshHit navHit, dist, NavMesh.AllAreas))
        {
            return navHit.position;
        }
        return origin;
    }
}