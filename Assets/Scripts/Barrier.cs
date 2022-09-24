using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Barrier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AmountOfMoneyText;
    
    public bool Attack = true;
    public float AmountOfMoney;
    private List<GameObject> _moneys=new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectMoney(other.gameObject);
            Follow();
        }
    }

    private void Follow()
    {
        GameManager.instance.isFollowing = Attack;
        Attack = !Attack;
    }

    private void CollectMoney(GameObject player)
    {
        if (!Attack)
        {
            Transform moneyContainer = player.GetComponentInChildren<MoneyContainer>().transform;
            AmountOfMoney+= moneyContainer.childCount * 100;
            for (int i = 0; i < moneyContainer.childCount; i++)
            {
                _moneys.Add(moneyContainer.GetChild(i).gameObject);
            }
            StartCoroutine(WaitAndDestroy());
        }
    }
    
    private IEnumerator WaitAndDestroy()
    {
        foreach (GameObject money in _moneys)
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(money);
        }

        AmountOfMoneyText.text = "Amount of Money: " + AmountOfMoney;

    }
}