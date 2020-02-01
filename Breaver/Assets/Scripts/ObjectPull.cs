using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPull : MonoBehaviour
{
    public GameObject fallingObject;
    public GameObject poolParent;
    private Queue<GameObject> pool;
    private int poolSize = 3;

    void Start()
    {
        pool = new Queue<GameObject>();
        IncreasePool();
    }

    public void ReturnToPool(GameObject toRecycle) {
        toRecycle.SetActive(false);
        toRecycle.gamefallingObject.transform.SetParent(poolParent.transform);
        pool.Enqueue(toRecycle);
    }


    private void IncreasePool() {
        
        for (int i = 0; i < poolSize; i++) {
            GameObject newfallingObject = Instantiate(fallingObject, poolParent.transform);
            Food newfallingObject = newfallingObject.GetComponent<Food>();
            newfallingObject.SetPool(this);
            newfallingObject.SetActive(false);
            pool.Enqueue(newfallingObject);
        }
    }

    public MovableObject GetfallingObject() {
        if (pool.Count == 0) {
            IncreasePool();
        }
        GameObject newfallingObject = pool.Dequeue();
        newfallingObject.SetActive(true);
        MovableObject movable = newfallingObject.GetComponent<MovableObject>();
        return movable;
    }
}