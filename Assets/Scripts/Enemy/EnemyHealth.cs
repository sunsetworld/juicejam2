using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    [SerializeField] private Canvas crosshairHUD;

    [SerializeField] private AudioClip explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(int healthToReduce)
    {
        health -= healthToReduce;
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Canvas cHUD = Instantiate(crosshairHUD);
            Destroy(cHUD);
        }
    }
    
}
