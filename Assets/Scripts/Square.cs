using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public bool isActive = false;
    public bool isOverlap = false;
    
    public Action Despawn;

    private void OnEnable()
    {
        
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

    private void Relocate()
    {
        isOverlap = false;
        transform.position = new Vector3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-4f, 4f), transform.position.z);
        if(isOverlap)
        {
            Relocate();
        }
    }
}
