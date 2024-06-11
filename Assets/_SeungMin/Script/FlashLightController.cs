using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlashLightController : MonoBehaviour
{

    public Transform playerHand;


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            // 손전등을 플레이어의 손 위치로 이동하고 부모를 설정
            transform.position = playerHand.position;
            transform.rotation = playerHand.rotation;
            transform.SetParent(playerHand);
        }
    }
}
