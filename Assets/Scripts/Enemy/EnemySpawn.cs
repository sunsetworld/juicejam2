using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawn : MonoBehaviour
{
    [FormerlySerializedAs("Enemy")] [SerializeField] private GameObject enemy;

    [SerializeField] private float spawnTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime/2);
            Instantiate(enemy, transform.position, quaternion.identity);
            Debug.Log("Enemy spawned!");
        }

    }
}
