using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class WilboShoot : MonoBehaviour
{
    [SerializeField] private AudioClip shootSound;
    
    [SerializeField] private bool isPlayer;
    
    [SerializeField] GameObject projectile;
    private Vector2 _projectileSpawnLocation;
    private quaternion _projectileSpawnRotation;

    public Transform gunL;
    public Transform gunR;
    private bool _gunUsed;

    [SerializeField] private float projectileForce = 20f;

    private MoneySystem _moneySystem;
    // Start is called before the first frame update
    void Start()
    {
        _moneySystem = FindObjectOfType<MoneySystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!_moneySystem.IsBankrupt())
                {
                    AudioSource.PlayClipAtPoint(shootSound, transform.position);
                    ShootProjectile(gunL);
                    ShootProjectile(gunR);
                }
            }
        }
    }

    void ShootProjectile(Transform firePoint)
    {
        GameObject bullet = Instantiate(projectile, firePoint.position ,firePoint.rotation);
        Rigidbody2D brb = bullet.GetComponent<Rigidbody2D>();
        brb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
    }
}

// Tutorials used:
// https://youtu.be/LNLVOjbrQj4
