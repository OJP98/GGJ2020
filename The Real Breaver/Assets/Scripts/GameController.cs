using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float maxStackHeight = 0;
    private float maxStackWidth = 0;
    private float decreasingRate = 0.01f;
    public GameObject water;
    public float originalDistance;

    void Start()
    {
        // GameObject[] lista = FindGameObjectsWithLayer();
        // InvokeRepeating("FindGameObjectsWithLayer", 1, 1);
    }

    void Update()
    {
        GameObject[] lista = FindGameObjectsWithLayer();
        originalDistance = Mathf.Abs(water.gameObject.transform.position.x);
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
                    //Water
                    maxStackWidth =  Mathf.Abs(go.transform.position.x);
                    // water.gameObject.transform.localScale =  originalDistance - maxStackWidth;
                    // water.position.x = -((water.size.x / 2) - originalDistance);
                }

                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - (decreasingRate*Time.deltaTime*7), go.transform.position.z);
            }
        }

        maxStackHeight -= decreasingRate;

        return gos;
    }
}
