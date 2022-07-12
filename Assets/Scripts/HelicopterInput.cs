using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterInput : MonoBehaviour
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public bool IsStart { get; private set; }

    void Update()
    {
        X = 0f;
        Y = 0f;
        IsStart = false;

        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
        IsStart = Input.GetKeyDown(KeyCode.R);
   
    }
}