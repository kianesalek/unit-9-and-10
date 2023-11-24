using System.Collections;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 10f;
    public float speed = 3f;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}