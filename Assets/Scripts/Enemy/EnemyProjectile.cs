using System;
using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private Canvas crosshairHUD;
    private Rigidbody2D _rb2d;
    private MoneySystem _mS;

    private CameraShaker _cameraShaker;
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        } else if (col.gameObject.CompareTag("Player"))
        {
            _mS = FindObjectOfType<MoneySystem>();
            _mS.DeductMoney(5000000);
            Destroy(gameObject);
        }
    }

    

}
