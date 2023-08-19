using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Car : MonoBehaviour
{
    [SerializeField] private float _accelerationForward;
    [SerializeField] private float _accelerationBack;
    [SerializeField] private float _accelerationInertion;
    [SerializeField] private float _maxSpeedForward;
    [SerializeField] private float _maxSpeedBack;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _multiplyRotate;
    [SerializeField] private float _maxSpeedRotate;

    private float _speed;

    private void Start()
    {
        _speed = 0;
    }

    private void Update()
    {
        UpdateSpeed();
        transform.position += transform.forward * _speed;
        transform.Rotate(0, GetRotate(), 0);
    }

    private float GetRotate()
    {
        float rotate = 0;

        if (Input.GetKey(KeyCode.D))
        {
            rotate += _speedRotate * _speed * _multiplyRotate * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotate -= _speedRotate * _speed * _multiplyRotate * Time.deltaTime;
        }

        Debug.Log(Mathf.Clamp(rotate, -_maxSpeedRotate, _maxSpeedRotate));

        return Mathf.Clamp(rotate, -_maxSpeedRotate, _maxSpeedRotate);
    }

    private void UpdateSpeed()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.W))
            {
                _speed += _accelerationForward * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                _speed -= _accelerationBack * Time.deltaTime;
            }
        }
        else
        {
            if (_speed > 0)
            {
                _speed = Mathf.Max(0, _speed - _accelerationInertion * Time.deltaTime);
            }
            else if (_speed < 0)
            {
                _speed = Mathf.Min(0, _speed + _accelerationInertion * Time.deltaTime);
            }
        }

        _speed = Mathf.Clamp(_speed, _maxSpeedBack, _maxSpeedForward);
    }
}
