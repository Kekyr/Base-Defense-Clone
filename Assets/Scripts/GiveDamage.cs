using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveDamage : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Vector3 _offset;
    private GameObject _bullet;
    private bool _isShooting;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && !other.gameObject.GetComponent<EnemyHealth>().isDeath)
        {
            if (GameManager.instance.isFollowing && !_isShooting)
            {
                _isShooting = true;
                StartCoroutine(Shoot(other.gameObject));
            }
        }
    }


    private IEnumerator Shoot(GameObject enemy)
    {
        _bullet = Instantiate(_bulletPrefab, transform.position + _offset, Quaternion.identity);
        _bullet.GetComponent<Bullet>().direction = (enemy.transform.position - _bullet.transform.position).normalized;
        _bullet.GetComponent<Bullet>().isFly = true;
        yield return new WaitForSeconds(1f);
        _isShooting = false;
    }
}