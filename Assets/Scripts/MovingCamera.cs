using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovingCamera : MonoBehaviour
{
    public Transform Target;
    [SerializeField] private float _smoothSpeed;

    private Transform _modifiedTarget;
    private Vector3 _offset;
    private Vector3 _desiredPosition;
    private Vector3 _smoothedPosition;

    private void Start()
    {
        _offset = transform.position;
    }

    private void FixedUpdate()
    {
        _desiredPosition = Target.position + _offset;
        _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, _smoothSpeed);
        transform.position = _smoothedPosition;
    }
}