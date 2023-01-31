using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class AddMoney : MonoBehaviour
{
    [FormerlySerializedAs("AmountToAdd")] [SerializeField] private float amountToAdd = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            MoneySystem moneySystem = col.GetComponent<MoneySystem>();
            moneySystem.AddMoney(amountToAdd);
            Debug.Log("Adding " + amountToAdd.ToString() + "To Player Balance.  ");
            Destroy(gameObject);
        }
    }
}
