using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScore : MonoBehaviour
{
    int score = 10;
    private int keyScore = 0;
    public bool isKeyAll = false;
    public GameObject keyCanvas;
    public Text finshText;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "key")
        {
            keyScore++;
            print("key");
            other.gameObject.SetActive(false);
        }
            
    }
    private void Update()
    {
        if (keyScore >= 3)
        {
            keyCanvas.SetActive(true);
            keyScore = 0;
            isKeyAll = true;
        }
        finshText.text = "최종 스코어는: " + score + "점 입니다, 수고하셨습니다";
    }
    public void ScoreDown()
    {
        score--;
    }
}
