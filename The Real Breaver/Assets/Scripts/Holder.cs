using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    public GameObject movableAnchor;
    Object obj;
    void Start()
    {
        obj = movableAnchor.GetComponentInChildren<Object>();
    }
    public bool HasMovable()
    {
        return obj != null;
    }

    public Object GetObject()
    {
        return obj;
    }

    public void SetMovable(Object newObj)
    {
        obj = newObj;
        newObj.gameObject.transform.SetParent(movableAnchor.transform);
        newObj.transform.localPosition = new Vector3(0,0,0);
    }

    public void RemoveMovable()
    {
        obj = null;
    }

    public void MakeMovable()
    {
        obj = movableAnchor.GetComponentInChildren<Object>();
    }
}
