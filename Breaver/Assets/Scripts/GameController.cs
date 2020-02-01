using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float maxStackHeight = 0;
    private float decreasingRate = 0.01f;

    void Start()
    {
        // GameObject[] lista = FindGameObjectsWithLayer();
        // InvokeRepeating("FindGameObjectsWithLayer", 1, 1);
    }

    void Update()
    {
        GameObject[] lista = FindGameObjectsWithLayer();
    }

    GameObject[] FindGameObjectsWithLayer(){
        GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject go in gos)
        {
            if (go.layer == 9)
            {
                if (go.transform.position.y > maxStackHeight)
                {
                    maxStackHeight = go.transform.position.y;
                }

                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - (decreasingRate*Time.deltaTime*7), go.transform.position.z);
            }
        }

        maxStackHeight -= decreasingRate;

        return gos;
    }
}
