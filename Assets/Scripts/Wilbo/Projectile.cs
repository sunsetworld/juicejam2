using System;
using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Canvas crosshairHUD;
    private Rigidbody2D _rb2d;
    private Crosshairs _cHairs;
    private MoneySystem _mS;

    private CameraShaker _cameraShaker;
    // Start is called before the first frame update
    void Start()
    {
        
        _rb2d = GetComponent<Rigidbody2D>();
        crosshairHUD.enabled = false;
        _cHairs = FindObjectOfType<Crosshairs>();
        _mS = FindObjectOfType<MoneySystem>();
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
        } else if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            CameraShaker.Instance.ShakeOnce(5f, 5f, 0.2f, 0.2f);
            _cHairs.EnemyKilled();
        }
    }

    

}
