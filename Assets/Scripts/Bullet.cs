using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    public bool isFly;
    public Vector3 direction;
    public float force;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        if (isFly)
        {
            Fly();
        }
    }

    private void Fly()
    {
        _rigidbody.AddForce(direction*force);
    }
    
}
