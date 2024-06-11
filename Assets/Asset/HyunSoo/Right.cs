using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    public QuizScore quiz;
    public GameObject Panel;
    public void OnClick()
    {
        Panel.SetActive(false);
    }
}
