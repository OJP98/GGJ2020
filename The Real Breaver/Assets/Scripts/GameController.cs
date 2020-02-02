using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float maxStackHeight = 0;
    private float maxStackWidth = 0;
    private float decreasingRate = 0.01f;
    public GameObject water;
    public float originalDistance;

    public Transform wave;
    public Text gameOver;

    private bool hasLost = false;
    public float speed = 5f;

    void Start()
    {
        // GameObject[] lista = FindGameObjectsWithLayer();
        // InvokeRepeating("FindGameObjectsWithLayer", 1, 1);
        originalDistance = water.gameObject.transform.position.x;

        hasLost = false;
        gameOver.enabled = false;
    }

    void Update()
    {
        GameObject[] lista = FindGameObjectsWithLayer();
        //Debug.Log(maxStackHeight);
        if (maxStackHeight < 5.05)
        {
            hasLost = true;
            gameOver.enabled = true;
        }

        if (wave.position.y < 6.7 && hasLost)
        {
            wave.position = new Vector3(wave.position.x, wave.position.y + Time.deltaTime * speed, wave.position.z);
        }
    }

    /*
    IEnumerator moveWave() {
        Debug.Log("HOla");
        while (wave.transform.position.y < 6.7) {
            yield return new WaitForSeconds(.1f);
            Debug.Log("Hola");
        }
        yield return null; 
    }*/

    GameObject[] FindGameObjectsWithLayer()
    {
        GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject go in gos)
        {
            if (go.layer == 9)
            {
                if (go.transform.position.y > maxStackHeight)
                {
                    maxStackHeight = go.transform.position.y + (go.GetComponent<BoxCollider>().size.y / 2);
                    maxStackWidth = Mathf.Abs(originalDistance - go.transform.position.x);
                    Debug.Log(go.transform.position.y);
                    Vector3 waterScale = water.gameObject.transform.localScale;
                    Vector3 waterPos = water.gameObject.transform.position;

                    water.gameObject.transform.localScale = new Vector3(maxStackWidth, waterScale.y, waterScale.z);

                    waterPos = new Vector3(((Mathf.Abs(maxStackWidth) / 2) + originalDistance), waterPos.y, waterPos.z);
                    water.gameObject.transform.position = waterPos;
                }

                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y - (decreasingRate * Time.deltaTime * 1), go.transform.position.z);
            }
        }

        maxStackHeight -= decreasingRate;

        return gos;
    }
}