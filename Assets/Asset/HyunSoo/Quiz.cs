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

    private string[] quizes = { "���� ������ â���� ����� �����ΰ���?", "���� �ô� ���������� �� �ܰ�� �̷���� �־�����?" ,
    "�Ϻ��� ���� ħ���� ���Ƴ� �����ֶ��� ��� �� �ñ⿡ �߻��߳���?", "���������� �Ͼ ������ �����ΰ���?", "�ѱ��� ������ ������ 3.1��� �Ͼ ������ �����ΰ���?",
    "���ѹα� �ӽ����ΰ� ������ ���ô� ����ΰ���?", "�ѱ� ������ �߹��� ������ �����ΰ���?", "�ѱ۳��� �� �� ��ĥ�ΰ���?", "���� �ô� 4�� ��ȭ �� ù ��° ��ȭ�� �����ΰ���?",
    "1920����� ��ǥ���� ���� ���� ���� ��ü�� �����ΰ���?", "1905�⿡ �Ϻ��� ���������� �ܱ����� ��Ż�� ������ �����ΰ���?"};

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
