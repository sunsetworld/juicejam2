using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMovement : MonoBehaviour
{
    [FormerlySerializedAs("movementSpeed")] [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed = 1f;
    [FormerlySerializedAs("WilboObj")] [SerializeField] private GameObject wilboObj;
    [SerializeField] private Transform wilboTransform;
    private WilboMovement _wilboMovement;
    [SerializeField] private float rotationModifier;
    
    // Start is called before the first frame update
    void Start()
    {
        _wilboMovement = FindObjectOfType<WilboMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (_wilboMovement != null)
        {
            MoveToPlayer();
            RotateTowardsPlayer();
        }
    }

    private void RotateTowardsPlayer()
    {
        Vector3 vectorToTarget = _wilboMovement.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion quatA = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, quatA, rotationSpeed * Time.deltaTime);
    }

    private void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wilboMovement.transform.position,
            movementSpeed * Time.deltaTime);
    }
}

// https://www.youtube.com/watch?v=RNPetUa8_PQ
// https://answers.unity.com/questions/1592029/how-do-you-make-enemies-rotate-to-your-position-in.html
