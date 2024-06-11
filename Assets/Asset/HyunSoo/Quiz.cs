using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Quiz : MonoBehaviour
{
    public GameObject quizPanel;
    public Text quiz;

    public Text wrongA;
    public Text wrongB;
    public Text wrongC;
    public Text answer;

    public ButtonShuffle shuffler;

    private string[] quizes = { "조선 왕조를 창건한 사람은 누구인가요?", "조선 시대 과거제도는 몇 단계로 이루어져 있었나요?" ,
    "일본의 조선 침략을 막아낸 임진왜란은 어느 왕 시기에 발생했나요?", "갑신정변이 일어난 연도는 언제인가요?", "한국의 독립을 선언한 3.1운동이 일어난 연도는 언제인가요?",
    "대한민국 임시정부가 수립된 도시는 어디인가요?", "한국 전쟁이 발발한 연도는 언제인가요?", "한글날은 몇 월 며칠인가요?", "조선 시대 4대 사화 중 첫 번째 사화는 무엇인가요?",
    "1920년대의 대표적인 항일 무장 투쟁 단체는 무엇인가요?", "1905년에 일본이 대한제국의 외교권을 박탈한 조약은 무엇인가요?"};

    public string[] wrongAnswerA;
    public string[] wrongAnswerB;
    public string[] wrongAnswerC;
    public string[] answerText;

    public Transform[] quizPos;

    public GameObject player;

    private int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            quizPanel.SetActive(true);
            quiz.text = quizes[i];
            wrongA.text = wrongAnswerA[i];
            wrongB.text = wrongAnswerB[i];
            wrongC.text = wrongAnswerC[i];
            answer.text = answerText[i];
            shuffler.ShuffleButtons();
            player.GetComponent<ThirdPersonController>().isPlayerRestricted = true;
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            transform.position = quizPos[i].position;
            transform.rotation = quizPos[i].rotation;
            transform.localScale = quizPos[i].localScale;
            i++;
        }
    }

}
