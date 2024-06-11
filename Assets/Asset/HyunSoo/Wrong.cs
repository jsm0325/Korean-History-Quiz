using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrong : MonoBehaviour
{
    public QuizScore quiz;
    public GameObject Panel;
    public void OnClick()
    {
        quiz.ScoreDown();
        Panel.SetActive(false);
    }
}
