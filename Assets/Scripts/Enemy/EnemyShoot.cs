using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private AudioClip shootSound;

    [SerializeField] GameObject projectile;
    private Vector2 _projectileSpawnLocation;
    private quaternion _projectileSpawnRotation;
    
    [SerializeField] private float projectileForce = 20f;

    private MoneySystem _moneySystem;
    
    public Transform gunL;
    public Transform gunR;

    [SerializeField] private float minTime = 2f;
    [SerializeField] private float maxTime = 10f;

    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
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

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            ShootProjectile(gunL);        
            ShootProjectile(gunR);
        }

    }
}

// Tutorials used:
// https://youtu.be/LNLVOjbrQj4
// https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-integer-in-c
// https://stackoverflow.com/questions/53139259/making-a-timer-in-unity

