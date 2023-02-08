using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private AudioClip shootSound;

    [SerializeField] GameObject projectile;
    private Vector2 _projectileSpawnLocation;
    private quaternion _projectileSpawnRotation;
    

    [SerializeField] private float projectileForce = 20f;

    private MoneySystem _moneySystem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
