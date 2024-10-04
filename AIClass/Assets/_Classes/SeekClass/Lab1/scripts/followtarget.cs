using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followtarget : MonoBehaviour
{
    public Transform[] waypoints;  // Array de puntos de patrullaje
    public float moveSpeed = 3f;
    public float waitTime = 1f;
    private int currentWaypointIndex = 0;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentWaypointIndex = Random.Range(0, waypoints.Length);
    }

    private void Update()
    {
        // Mover hacia el waypoint actual
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        agent.SetDestination(targetWaypoint.position);

        // Cambiar al siguiente waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 1.2f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1);

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        
    }

   
}
