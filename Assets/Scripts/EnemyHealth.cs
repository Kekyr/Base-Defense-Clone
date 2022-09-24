using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _amountOfHealth;
    [SerializeField] private GameObject _moneyPrefab;

    private CapsuleCollider _capsuleCollider;
    private Animator _animator;
    private EnemyMovement _movement;
    
    public bool isDeath;

    private void Start()
    { 
        _animator = GetComponent<Animator>();
        _movement = GetComponent<EnemyMovement>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }
    
    public void GetDamage()
    {
        _amountOfHealth -= 30;
        CheckAmountOfHealth();
    }

    private void CheckAmountOfHealth()
    {
        if (_amountOfHealth <= 0 && !isDeath)
        {
            isDeath = true;
            _movement.enabled = false;
            _animator.SetBool("Punching",false);
            _animator.SetTrigger("Death");
            _capsuleCollider.enabled = false;
            StartCoroutine(WaitAndDestroy());
        }
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        if (Random.value <= 0.8f)
        {
            Instantiate(_moneyPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
