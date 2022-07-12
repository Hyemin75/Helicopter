using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propellerMovemont : MonoBehaviour
{
    public float RotationSpeed = 1.5f;
    Rigidbody _rigidbody;


    private HelicopterInput _input;
    private HelicopterMovement _HelicopterMovement;

    private void Awake()
    {
        _input = GetComponent<HelicopterInput>();
        _rigidbody = GetComponent<Rigidbody>();

        _HelicopterMovement = GetComponent<HelicopterMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
