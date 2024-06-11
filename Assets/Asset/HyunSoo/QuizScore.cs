using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizScore : MonoBehaviour
{
    int score = 10;

    public void ScoreDown()
    {
        score--;
    }
}
