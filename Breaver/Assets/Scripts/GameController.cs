using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] lista = FindGameObjectsWithLayer(9);
    }

    // Update is called once per frame
    void Update()
    {

    }

    GameObject[] FindGameObjectsWithLayer(int layer){
        GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[]; //will return an array of all GameObjects in the scene
        foreach (GameObject go in gos)
        {
            if (go.layer == layer)
            {
                Debug.Log(go.name);
            }
        }
        return gos;
 }
}
