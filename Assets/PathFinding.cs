using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    public Transform player;
    public float enemyRange = 10f;
    public float loopSpeed = 3f;
    public float enemySpeed = 5f;
    public Transform[] patrolPoints;
    private NavMeshAgent nav;
    private int destPoint;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.autoBraking = false;
        GoToNextPoint();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < enemyRange)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer()
    {
        nav.speed = enemySpeed;
        nav.destination = player.position;
    }

    void Patrol()
    {
        nav.speed = loopSpeed;

        if (!nav.pathPending && nav.remainingDistance < 0.5f)
            GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        nav.destination = patrolPoints[destPoint].position;
        destPoint = (destPoint + 1) % patrolPoints.Length;
    }
}