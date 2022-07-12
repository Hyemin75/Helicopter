using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float UpSpeed = 1.0f;
    public float RotationSpeed = 1.5f;
    public float MaxPropellerSpeed = 10f;
    public GameObject Propeller;

    private HelicopterInput _input;
    private Rigidbody _rigidbody;
    public bool _isTurnOn = false;

    private void Awake()
    {
        _input = GetComponent<HelicopterInput>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(_input.IsStart)
        {
            _isTurnOn = !_isTurnOn;
        }

        if(_isTurnOn)
        {
            onTurnOn();
        }
        else
        {
            onTurnOff();
        }
    }

    private float _propellerSpeed = 0f;
    private void onTurnOn()
    {
        _propellerSpeed = Mathf.Lerp(_propellerSpeed, MaxPropellerSpeed, Time.deltaTime);
        rotatePropellers();

        if (MaxPropellerSpeed - _propellerSpeed > 0.5f)
        {
            return;
        }

        if (_rigidbody.useGravity)
        {
            _rigidbody.useGravity = false;
        }

        if (_input.Y == 0)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            _rigidbody.AddForce(0f, _input.Y * UpSpeed, 0f);
        }
        transform.Rotate(0f, _input.X * RotationSpeed, 0f);
    }

    private void onTurnOff()
    {
        _propellerSpeed = Mathf.Lerp(_propellerSpeed, 0f, Time.deltaTime);
        rotatePropellers();

        if (_rigidbody.useGravity == false)
        {
            _rigidbody.useGravity = true;
        }

    }

    private void rotatePropellers()
    {
        Propeller.transform.Rotate(0f, _propellerSpeed, 0f);
    }

}
