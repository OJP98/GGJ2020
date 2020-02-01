using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    public List<Object> objectList;
    Object currentObject;
    void Start()
    {
        objectList = new List<Object>();
    }

    public Object GetSelected()
    {
        return currentObject;
    }

    private void OnTriggerEnter(Collider objeto) {
        Object obj = objeto.GetComponent<Object>();
        if(obj != null)
        {
            objectList.Add(obj);
            ChooseObj();
        }
    }

    private void OnTriggerExit(Collider objeto) {
        Object obj = objeto.GetComponent<Object>();
        if (obj != null)
        {
            objectList.Remove(obj);
            ChooseObj();
        }
    }

    private void ChooseObj()
    {
        if (objectList.Count > 0)
        {
            Object chosenObj = null;
            float dist = 1500f;

            foreach (Object obj in objectList)
            {
                float newDist = Vector3.Distance(transform.position, obj.transform.position);
                if (newDist < dist)
                {
                    dist = newDist;
                    chosenObj = obj;
                }
            }

            if (chosenObj != null) currentObject = chosenObj;
        }
        else
        {
            currentObject = null;
        }
    }
}
