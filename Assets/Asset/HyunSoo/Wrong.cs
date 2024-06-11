using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrong : MonoBehaviour
{
    public QuizScore quiz;
    public GameObject Panel;
    public GameObject player;
    public ScenarioEngine sc;
    public void OnClick()
    {
        quiz.ScoreDown();
        player.GetComponent<ThirdPersonController>().isPlayerRestricted = false;
        sc.isPlayerRestricted = false;
        Panel.SetActive(false);
    }
}
