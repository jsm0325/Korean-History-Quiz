using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    public QuizScore quiz;
    public GameObject Panel;
    public GameObject player;
    public ScenarioEngine sc;
    public void OnClick()
    {
        Panel.SetActive(false);
        player.GetComponent<ThirdPersonController>().isPlayerRestricted = false;
        sc.isPlayerRestricted = false;
    }
}
