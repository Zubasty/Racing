using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotate;

    private void Update()
    {
        Vector3 shift = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            shift += _speed * transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            shift -= _speed * transform.forward;
        }

        transform.position += shift * Time.deltaTime;
        float rotate = 0;

        if(Input.GetKey(KeyCode.D))
        {
            rotate += _speedRotate;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotate -= _speedRotate;
        }

        transform.Rotate(0, rotate * Time.deltaTime, 0);
    }
}
