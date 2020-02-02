using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRain : MonoBehaviour
{
    public float fallingTime = 0f;
    //public GameObject cubo;
    //public GameObject esfera;
    private int totalFallenObjects;
    float currentTime = 0f;
    float currentTime2 = 0f;
    public ObjectPull pull;
    private float increaseRatio;

    //public FallingObject objectFalled;

    // Start is called before the first frame update
    void Start()
    {
        //sendObject();
        totalFallenObjects = 0;
        //  objectPool.Add(cubo);
        //  objectPool.Add(esfera);
        increaseRatio = 8f;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        currentTime2 += Time.deltaTime;
        if (currentTime2 >= increaseRatio)
        {
            if (fallingTime <= 1.5f)
            {
                fallingTime = 2.25f;
            }
            else
            {
                fallingTime -= 0.25f;
                currentTime2 = 0f;
            }
        }
        if (currentTime >= fallingTime)
        {
            sendObject();
        }
    }

    void sendObject()
    {
        //int fallingObjectNumber = Random.Range(0, objectPool.Count);
        currentTime = 0f;
        //GameObject fallingObject = objectPool[fallingObjectNumber];
        Vector3 posicion = new Vector3(Random.Range(3, 7), 15, 0);
        //Instantiate(fallingObject, posicion, Quaternion.identity);
        GameObject fallingObject = pull.GetfallingObject();
        fallingObject.gameObject.transform.position = posicion;
        totalFallenObjects += 1;
    }
}
