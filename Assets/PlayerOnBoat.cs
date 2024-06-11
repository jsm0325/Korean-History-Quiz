using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerOnBoat : MonoBehaviour
{
    public GameObject finishUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.SetParent(transform);
            other.GetComponent<ThirdPersonController>().isPlayerRestricted = true;
            finishUI.SetActive(true);
        }
    }
}
