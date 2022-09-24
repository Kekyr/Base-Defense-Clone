using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _amountOfHealth;
    private CapsuleCollider _capsuleCollider;
    private TextMeshProUGUI _hpText;

    private Animator _animator;
    public bool isDeath;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _hpText = GameObject.FindWithTag("HP").GetComponent<TextMeshProUGUI>();
    }
    public void GetDamage(Animator enemyAnimator)
    {
        _amountOfHealth -= 1;
        if (_amountOfHealth >= 0)
        {
            _hpText.text = "HP: " + _amountOfHealth;
        }
        CheckAmountOfHealth(enemyAnimator);
    }

    private void CheckAmountOfHealth(Animator enemyAnimator)
    {
        if (_amountOfHealth <= 0 && !isDeath)
        {
            GameManager.instance.isFollowing = false;
            _capsuleCollider.enabled = false;
            _animator.SetTrigger("Death");
            enemyAnimator.SetBool("Punching",false);
            isDeath = true;
            GameManager.instance.TurnOnAndOffRestartWindow(true);
        }
    }
}
