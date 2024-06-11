using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrong : MonoBehaviour
{
    public QuizScore quiz;
    public GameObject Panel;
    public GameObject player;
    public void OnClick()
    {
        quiz.ScoreDown();
        player.GetComponent<ThirdPersonController>().isPlayerRestricted = false;
        Panel.SetActive(false);
    }
}
