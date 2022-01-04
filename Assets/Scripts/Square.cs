using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public bool isActive = false;
    public bool isOverlap = false;
    
    public Action Despawn;

    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.localScale = new Vector3(UnityEngine.Random.Range(0.5f, 1f), UnityEngine.Random.Range(0.5f, 1f), 1f);
        Relocate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isActive)
        {
            isOverlap = true;
        }
    }

    public void Relocate()
    {
        isActive = false;
        isOverlap = false;
        transform.position = new Vector3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-4f, 4f), transform.position.z);
        if(isOverlap)
        {
            Relocate();
        }

        isActive = true;
        GiveRandomForce();
    }

    private void GiveRandomForce()
    {
        float force = UnityEngine.Random.Range(1f, 5f);
        Vector2 _moveDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        _body.AddForce(_moveDirection * force, ForceMode2D.Impulse);
    }
}
