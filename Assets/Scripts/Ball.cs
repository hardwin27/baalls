using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float _moveSpeed = 5f;
    private Vector2 _moveDirection;
    
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        _body.AddForce(_moveDirection * _moveSpeed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        /*print(_body.velocity.magnitude);*/
    }
}
