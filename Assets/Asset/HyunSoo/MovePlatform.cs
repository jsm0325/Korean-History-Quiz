using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private bool isLeft = false;
    public float moveSpeed = 10.0f;
    private bool isUp = false;
    public bool isRightOrUp = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0f, 2.0f);
    }

    private void Update()
    {
        if(isRightOrUp) 
        {
            if (isLeft)
                transform.position -= new Vector3(0, 0, moveSpeed) * Time.deltaTime;
            else
                transform.position += new Vector3(0, 0, moveSpeed) * Time.deltaTime;
        }
        else
        {
            if (!isUp)
                transform.position -= new Vector3(0, moveSpeed, 0) * Time.deltaTime;
            else
                transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;
        }    
        
    }

    void Move()
    {
        isLeft = !isLeft;
        isUp = !isUp;
    }
}
