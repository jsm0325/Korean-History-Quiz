using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10f;
    public float stopDistance = 2f; // 플레이어와의 멈추는 거리 설정
    private NavMeshAgent navMeshAgent;
    private bool playerDetected = false;
    private Animator animator;
    private ScenarioEngine scenarioEngine;

    void Start()
    {  
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        navMeshAgent.stoppingDistance = stopDistance; // 멈추는 거리 설정
        scenarioEngine = FindObjectOfType<ScenarioEngine>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= detectionRadius)
        {
            playerDetected = true;
            navMeshAgent.SetDestination(player.position);
        }
        // NavMeshAgent의 속도를 애니메이터의 Speed 파라미터로 설정
        float speed = navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            navMeshAgent.isStopped = true;
            transform.LookAt(player);
            // 시나리오 엔진으로 시나리오 스크립트 실행
            scenarioEngine.StartScenario("story");
        }
    }
}
