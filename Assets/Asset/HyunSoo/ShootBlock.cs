using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBlock : MonoBehaviour
{
    public Transform startpos;
    private Vector3 startPosition;
    private Vector3 bounceStartPosition;
    private bool isBouncing = false;
    private float bounceTime = 0f;
    public float bounceDuration = 3f;
    private Transform player;
    private void Start()
    {
        startPosition = startpos.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (isBouncing)
        {
            bounceTime += Time.deltaTime;
            float t = bounceTime / bounceDuration;
            player.transform.position = Vector3.Lerp(bounceStartPosition, startPosition, t);

            if (t >= 3f)
            {
                isBouncing = false;
                player.GetComponent<CharacterController>().enabled = true;
                bounceTime = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            print("bounce");
            // Start the bounce
            bounceStartPosition = player.transform.position;
            isBouncing = true;
            player.GetComponent<CharacterController>().enabled = false;
            bounceTime = 0f;
        }
    }
}
