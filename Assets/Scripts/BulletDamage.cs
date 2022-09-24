using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private EnemyHealth _health;

    private void Start()
    {
        _health = GetComponent<EnemyHealth>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            _health.GetDamage();
        }
        
    }
}
