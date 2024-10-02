using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAgent : MonoBehaviour
{
   NavMeshAgent agent;
   Vector3 targetWaypoint;
   public float radius = 10;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetWaypoint = RandomNavmeshLocation();
        agent.SetDestination(targetWaypoint);
    }
    public Vector3 RandomNavmeshLocation()
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        Debug.Log(finalPosition);
        return finalPosition;

    }

    void Update()
    {

        // Cambiar al siguiente waypoint
        if (Vector3.Distance(transform.position, targetWaypoint) < 1.2f)
        {
            targetWaypoint = RandomNavmeshLocation();
            agent.SetDestination(targetWaypoint);
        }
    }
}
