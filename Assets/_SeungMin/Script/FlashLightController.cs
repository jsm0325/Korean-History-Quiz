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


            // �������� �÷��̾��� �� ��ġ�� �̵��ϰ� �θ� ����
            transform.position = playerHand.position;
            transform.rotation = playerHand.rotation;
            transform.SetParent(playerHand);
        }
    }
}
