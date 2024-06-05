using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10f;
    private NavMeshAgent navMeshAgent;
    private bool playerDetected = false;
    private Animator animator;

    void Start()
    {  
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            playerDetected = true;
            navMeshAgent.SetDestination(player.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.isStopped = true;
            transform.LookAt(player);
            // 시나리오 엔진으로 시나리오 스크립트 실행
        }
    }
}
