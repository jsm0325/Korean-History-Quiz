using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShuffle : MonoBehaviour
{
    public GameObject[] buttons; // 4개의 버튼을 여기에 할당

    public void ShuffleButtons()
    {
        // 버튼들의 원래 위치를 저장
        Vector3[] originalPositions = new Vector3[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            originalPositions[i] = buttons[i].transform.position;
        }

        // 랜덤으로 셔플된 인덱스 배열 생성
        System.Random rand = new System.Random();
        for (int i = 0; i < buttons.Length; i++)
        {
            int randomIndex = rand.Next(i, buttons.Length);
            Vector3 temp = originalPositions[i];
            originalPositions[i] = originalPositions[randomIndex];
            originalPositions[randomIndex] = temp;
        }

        // 셔플된 위치를 버튼들에 적용
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.position = originalPositions[i];
        }
    }
}
