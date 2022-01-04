﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _moveSpeed = 5f;
    /*private Vector2 _moveDirection;*/
    private Vector3? _targetPosition = null;
    
    private Rigidbody2D _body;

    private Camera _mainCam;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        /*_moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        _body.AddForce(_moveDirection * _moveSpeed, ForceMode2D.Impulse);*/
        _mainCam = Camera.main;
    }

    private void Update()
    {
        GetBallDirection();
        /*print(_body.velocity.magnitude);*/
    }

    private void FixedUpdate()
    {
        MoveBall();
    }

    private void GetBallDirection()
    {
        /*float horDir = Input.GetAxisRaw("Horizontal");
        float verDir = Input.GetAxisRaw("Vertical");
        _moveDirection = new Vector2(horDir, verDir);*/

        /*if(Input.touchCount > 0)
        {
            print(_mainCam.ScreenToWorldPoint(Input.GetTouch(0).position));
        }*/

        if(Input.GetButtonDown("Fire2"))
        {
            Vector3 tempPosition = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition = new Vector3(tempPosition.x, tempPosition.y, transform.position.z);
        }
    }

    private void MoveBall()
    {
        /*_body.velocity = _moveDirection.normalized * _moveSpeed;*/

        if(_targetPosition != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, (Vector3)_targetPosition, _moveSpeed * Time.fixedDeltaTime);
        }
    }
}
