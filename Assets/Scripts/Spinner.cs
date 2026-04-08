using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotationSpeedY = 15f; 

    void Update()
    {
        transform.Rotate(0f, rotationSpeedY * Time.deltaTime, 0f);       
    }
}