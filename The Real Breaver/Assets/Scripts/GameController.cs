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
        originalDistance = water.gameObject.transform.position.x;
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
                    maxStackWidth =  Mathf.Abs(originalDistance - go.transform.position.x);

                    Vector3 waterScale = water.gameObject.transform.localScale;
                    Vector3 waterPos = water.gameObject.transform.position;

                    water.gameObject.transform.localScale = new Vector3(maxStackWidth, waterScale.y, waterScale.z);

                    waterPos = new Vector3(((Mathf.Abs(maxStackWidth) / 2) + originalDistance), waterPos.y, waterPos.z);
                    water.gameObject.transform.position = waterPos;
                }

                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - (decreasingRate*Time.deltaTime*7), go.transform.position.z);
            }
        }

        maxStackHeight -= decreasingRate;

        return gos;
    }
}
