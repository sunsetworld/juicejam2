using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MoneySystem : MonoBehaviour
{
    [FormerlySerializedAs("bank_balance")] [SerializeField] private float bankBalance = 100000.00f;

    [FormerlySerializedAs("money_deduct")] [SerializeField] private float moneyDeduct = 100f;

    [FormerlySerializedAs("CashMachineClip")] [SerializeField] private AudioClip cashMachineClip; 
    
    private bool _isBankrupt = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (bankBalance > 0)
        {
            bankBalance -= moneyDeduct * Time.deltaTime;
            // print(bankBalance);
        } else if (bankBalance <= 0)
        {
            _isBankrupt = true;
            WilboMovement wb = FindObjectOfType<WilboMovement>();
            wb.IsDead();
            StartCoroutine(EndGame());
        }
    }

    public void AddMoney(float moneyToAdd)
    {
        bankBalance += moneyToAdd * Time.deltaTime;
        AudioSource.PlayClipAtPoint(cashMachineClip, transform.position);
        // print(bankBalance);
    }
    
    public void DeductMoney(float moneyToDeduct)
    {
        bankBalance -= moneyToDeduct * Time.deltaTime;
        // print(bankBalance);
    }

    public float GetMoney()
    {
        return bankBalance;
    }
    


    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");

    }

    public bool IsBankrupt()
    {
        return _isBankrupt;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            float moneyToDeduct = bankBalance * 0.8f;
            DeductMoney(moneyToDeduct);
        }
    }
}
