using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _force;
    private Rigidbody _rigidbody;
    private Animator _animator;
    
    private Vector3 _currentDirection;
    private Vector3 _newDirection;
    private bool _isRunning;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    public void Move(Vector3 newDirection)
    {
        _newDirection = newDirection;
        IsRunning();
        if (gameObject.CompareTag("Player"))
        {
            _rigidbody.AddForce(_newDirection*_speed);
        }
        else
        {
            _rigidbody.AddForce(_newDirection*_force);
        }
    }

    private void IsRunning()
    {
        if (IsMoving() && !_isRunning)
        {
            ChangeDirection();
            Rotate();
            _animator.SetTrigger("Running");
            IsRunning(true);
        }
        else if (IsMoving() && IsDirectionChanged() && _isRunning)
        {
            ChangeDirection();
            Rotate();
        }
        else if (_newDirection == Vector3.zero && _isRunning)
        {
            _animator.SetTrigger("DynIdle");
            IsRunning(false);
        }
    }

    private void IsRunning(bool isRunning)
    {
        _isRunning = isRunning;
    }

    private void ChangeDirection()
    {
        _currentDirection = _newDirection;
    }

    private bool IsMoving()
    {
        return !ComparePoints(_newDirection, Vector3.zero, 0.01f);
    }

    private void Rotate()
    {
        _rigidbody.rotation = Quaternion.LookRotation(_currentDirection);
    }

    private bool IsDirectionChanged()
    {
        return !ComparePoints(_currentDirection, _newDirection, 0.001f);
    }

    private bool ComparePoints(Vector3 point1, Vector3 point2, float tolerance)
    {
        return Mathf.Abs(Vector3.Distance(point1, point2)) <= tolerance;
    }
}