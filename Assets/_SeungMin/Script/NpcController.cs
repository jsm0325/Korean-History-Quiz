using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10f;
    public float stopDistance = 2f; // �÷��̾���� ���ߴ� �Ÿ� ����
    private NavMeshAgent navMeshAgent;
    private bool playerDetected = false;
    private Animator animator;
    private ScenarioEngine scenarioEngine;

    void Start()
    {  
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.stoppingDistance = stopDistance; // ���ߴ� �Ÿ� ����
        scenarioEngine = FindObjectOfType<ScenarioEngine>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            playerDetected = true;
            navMeshAgent.SetDestination(player.position);
        }
        // NavMeshAgent�� �ӵ��� �ִϸ������� Speed �Ķ���ͷ� ����
        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.isStopped = true;
            transform.LookAt(player);
            // �ó����� �������� �ó����� ��ũ��Ʈ ����
            scenarioEngine.StartScenario("story");
        }
    }
}
