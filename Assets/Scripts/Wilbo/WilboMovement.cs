using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class WilboMovement : MonoBehaviour
{
    private Transform _transform;
    [FormerlySerializedAs("_rigidbody2D")] private Rigidbody2D _rb2d;
    [SerializeField] private Camera cam;

    [FormerlySerializedAs("moveSpeed")] [SerializeField] float rotationSpeed = 50f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 1f;
    private Vector2 _movement;
    private Vector2 _mousePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RotatePlayer();
        MovePlayer();
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    /*    

        Vector2 viewDirection = _mousePosition - _rb2d.position;
        float angle = (Mathf.Atan2(viewDirection.y, viewDirection.x) * Mathf.Rad2Deg -90f) * mouseSensitivity;
        _rb2d.rotation = angle;
    */
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
        {
            // _transform.position += _transform.up * moveSpeed * Time.fixedDeltaTime;
            _rb2d.position = _rb2d.position + (Vector2)(_transform.up * moveSpeed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
        {
            _rb2d.position = _rb2d.position + (Vector2)(-_transform.up * moveSpeed * Time.fixedDeltaTime);
        }


    }
}
// Tutorials used: https://answers.unity.com/questions/609527/how-do-i-make-a-game-object-move-in-the-direction.html?childToView=613109#answer-613109