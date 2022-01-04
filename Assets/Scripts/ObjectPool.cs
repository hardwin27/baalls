using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private int _size = 0;
    private Transform _parent;
    private Queue<GameObject> _gameObjects;

    public void Create(Transform parent, GameObject prefab, int size)
    {
        _gameObjects = new Queue<GameObject>();
        _size = size;
        _parent = parent;

        for (int i = 0; i < size; i++)
        {
            GameObject gameObject = Instantiate(prefab);
            gameObject.transform.SetParent(parent);

            _gameObjects.Enqueue(gameObject);
        }
    }

    public GameObject Spawn()
    {
        GameObject gameObject;

        try
        {
            gameObject = _gameObjects.Dequeue();
        }
        catch
        {
            return null;
        }

        gameObject.transform.position = _parent.position;
      /*  float range = 1f;

        Vector3 offset = new Vector3(Random.Range(-range, range + 1f), Random.Range(-range, range + 1f), 0f);
        gameObject.transform.position += offset;*/

        return gameObject;
    }

    public void Despawn(GameObject gameObject)
    {
        gameObject.SetActive(false);
        _gameObjects.Enqueue(gameObject);
    }

    public bool IsPoolEmpty()
    {
        return _gameObjects.Count <= 0;
    }
}
