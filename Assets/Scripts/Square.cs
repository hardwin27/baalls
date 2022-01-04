using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = new Vector3(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), 1f);
        transform.position = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), transform.position.z);
    }
}
