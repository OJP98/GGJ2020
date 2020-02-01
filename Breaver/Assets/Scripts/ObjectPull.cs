using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingObjectPull : MonoBehaviour
{
    public GamefallingObject fallingObject;
    public GamefallingObject poolParent;
    private Queue<GamefallingObject> pool;
    private int poolSize = 3;

    void Start()
    {
        pool = new Queue<GamefallingObject>();
        IncreasePool();
    }

    public void ReturnToPool(GamefallingObject toRecycle) {
        toRecycle.SetActive(false);
        toRecycle.gamefallingObject.transform.SetParent(poolParent.transform);
        pool.Enqueue(toRecycle);
    }


    private void IncreasePool() {
        
        for (int i = 0; i < poolSize; i++) {
            GamefallingObject newfallingObject = Instantiate(fallingObject, poolParent.transform);
            Food newfallingObject = newfallingObject.GetComponent<Food>();
            newfallingObject.SetPool(this);
            newfallingObject.SetActive(false);
            pool.Enqueue(newfallingObject);
        }
    }

    public MovablefallingObject GetfallingObject() {
        if (pool.Count == 0) {
            IncreasePool();
        }
        GamefallingObject newfallingObject = pool.Dequeue();
        newfallingObject.SetActive(true);
        MovablefallingObject movable = newfallingObject.GetComponent<MovablefallingObject>();
        return movable;
    }
}