using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour
{
    [SerializeField] private Canvas crosshairHUD;
    // Start is called before the first frame update
    void Start()
    {
        crosshairHUD.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyKilled()
    {
        StartCoroutine(Display());
    }

    IEnumerator Display()
    {
        crosshairHUD.enabled = true;
        yield return new WaitForSeconds(0.8f);
        crosshairHUD.enabled = false;
    }
    
}
