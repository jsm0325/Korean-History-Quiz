using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShuffle : MonoBehaviour
{
    public GameObject[] buttons; // 4���� ��ư�� ���⿡ �Ҵ�

    public void ShuffleButtons()
    {
        // ��ư���� ���� ��ġ�� ����
        Vector3[] originalPositions = new Vector3[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            originalPositions[i] = buttons[i].transform.position;
        }

        // �������� ���õ� �ε��� �迭 ����
        System.Random rand = new System.Random();
        for (int i = 0; i < buttons.Length; i++)
        {
            int randomIndex = rand.Next(i, buttons.Length);
            Vector3 temp = originalPositions[i];
            originalPositions[i] = originalPositions[randomIndex];
            originalPositions[randomIndex] = temp;
        }

        // ���õ� ��ġ�� ��ư�鿡 ����
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].transform.position = originalPositions[i];
        }
    }
}
