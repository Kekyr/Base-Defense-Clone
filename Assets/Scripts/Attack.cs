using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameObject.GetComponentInParent<EnemyHealth>().isDeath)
        {
            _animator.SetBool("Punching",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !gameObject.GetComponentInParent<EnemyHealth>().isDeath)
        {
            _animator.SetBool("Punching",false);
        }
    }

}
