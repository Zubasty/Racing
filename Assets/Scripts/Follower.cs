using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    private void Update()
    {
        _targetPosition = _target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
        //transform.LookAt(_target);
    }
}
