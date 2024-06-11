using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform door;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    public QuizScore player;
    public GameObject keyCanvas;

    private void Start()
    {
        closedRotation = door.transform.rotation;
        openRotation = Quaternion.Euler(-90, 0, -120);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && player.isKeyAll == true)
        {
            StartCoroutine("Door");
            keyCanvas.SetActive(false);
        }
    }
    private IEnumerator Door()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 2.0f)
        {
            door.rotation = Quaternion.Slerp(closedRotation, openRotation, elapsedTime / 2.0f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
