using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawn : MonoBehaviour
{
    public float radius = 10;
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] GameObject blackBoard;
    [SerializeField] int zombies = 10;
    void Start()
    {
        for (int i = 0; i < zombies; i++)
        Instantiate(zombiePrefab, RandomNavmeshLocation(), Quaternion.identity,blackBoard.transform);

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

        return finalPosition;

    }


}
