using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class HUD : MonoBehaviour
{
    private MoneySystem _mM;
    [FormerlySerializedAs("MoneyTxt")] [SerializeField] private TMP_Text moneyTxt;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _mM = FindObjectOfType<MoneySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_mM.GetMoney() >= 0)
        {
            moneyTxt.text = "£" + _mM.GetMoney().ToString("F2");
        }
        else if (_mM.GetMoney() < 0)
        {
            moneyTxt.text = "£Bankrupt!";
        }
    }
}
