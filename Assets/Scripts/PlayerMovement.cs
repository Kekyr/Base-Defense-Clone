using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private FloatingJoystick _joystick;
    
    private Movement _movement;
    private Health _health;
    
    private Vector3 _newDirection;
    
    private void Start()
    {
        _movement = GetComponent<Movement>();
        _health = GetComponent<Health>();
        _joystick = FindObjectOfType<FloatingJoystick>();
    }

    private void Update()
    {
        _newDirection = new Vector3(_joystick.Direction.x, 0,_joystick.Direction.y);
    }
    
    private void FixedUpdate()
    {
        if (!_health.isDeath)
        {
            _movement.Move(_newDirection);
        }
    }
}
