using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float rotateSpeed;
    public bool clockwise;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (clockwise)
        {
            transform.Rotate(new Vector3(0, 0, -rotateSpeed * Time.deltaTime));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
        }
    }
}
