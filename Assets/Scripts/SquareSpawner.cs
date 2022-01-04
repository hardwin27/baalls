using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private GameObject _squarePrefab;
    private int _poolSize;

    /*private IObjectPool _objectPooler;*/

    private void Start()
    {
        _poolSize = Random.Range(5, 10);

        _pool.Create(transform, _squarePrefab, _poolSize);
        while(!_pool.IsPoolEmpty())
        {
            _pool.Spawn();
        }
    }
}
