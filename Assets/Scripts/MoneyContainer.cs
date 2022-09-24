using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyContainer : MonoBehaviour
{
   private Vector3 _offset=new Vector3(0,0,0);
   private GameObject _oldParent;
   
   public void AddMoney(GameObject money)
   {
      if (money.transform.parent.gameObject.CompareTag("PackOfMoney"))
      {
         Debug.Log("Pack of money");
         _oldParent = money.transform.parent.gameObject;
         money.transform.parent = gameObject.transform;
         Destroy(_oldParent);
      }
      else
      {
         money.transform.parent = gameObject.transform;
      }
      money.transform.localPosition = Vector3.zero + _offset;
      money.transform.localRotation=Quaternion.Euler(90f,90f,0);
      _offset.y+=0.06f;
   }
}
