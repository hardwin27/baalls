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

            Square tempSquare = gameObject.GetComponent<Square>();

            tempSquare.Despawn = () =>
            {
                Despawn(gameObject);
            };

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

        return gameObject;
    }

    public void Despawn(GameObject gameObject)
    {
        gameObject.SetActive(false);
        _gameObjects.Enqueue(gameObject);

        StartCoroutine(Respawn(gameObject));
    }

    public IEnumerator Respawn(GameObject respawnedObject)
    {
        yield return new WaitForSeconds(3f);
        respawnedObject.SetActive(true);
        respawnedObject.GetComponent<Square>().Relocate();
        _gameObjects.Enqueue(respawnedObject);
    }

    public bool IsPoolEmpty()
    {
        return _gameObjects.Count <= 0;
    }
}
