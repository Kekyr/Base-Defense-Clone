using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamage : MonoBehaviour
{
    private Health _health;
    private void Start()
    {
        _health = GetComponent<Health>();
    }
    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Enemy"))
        {
            Debug.Log("Getting damage!");
            _health.GetDamage(collisionInfo.collider.gameObject.GetComponent<Animator>());
        }
    }
}
