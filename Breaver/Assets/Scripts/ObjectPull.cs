﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPull : MonoBehaviour
{
    public GameObject[] fallingObject;
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
        toRecycle.gameObject.transform.SetParent(poolParent.transform);
        pool.Enqueue(toRecycle);
    }


    private void IncreasePool() {
        for (int i = 0; i < poolSize; i++) {
            int fallingObjectNumber = Random.Range(0, fallingObject.Length);
            GameObject newObject = Instantiate(fallingObject[fallingObjectNumber], poolParent.transform);
            FallingObject newfallingObject = newObject.GetComponent<FallingObject>();
            newfallingObject.SetPool(this);
            newObject.SetActive(false);
            pool.Enqueue(newObject);
        }
    }

    public GameObject GetfallingObject() {
        if (pool.Count == 0) {
            IncreasePool();
        }
        GameObject newfallingObject = pool.Dequeue();
        newfallingObject.SetActive(true);
        return newfallingObject;
    }


}