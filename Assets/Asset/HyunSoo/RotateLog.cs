using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLog : MonoBehaviour
{
    public float rotateSpeed = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
    }
}
