using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private Rigidbody rb;
    public bool isStack = false;
    public bool thrown = false;
    public float moveSpeed = 0.1f;
    private IEnumerator coroutine;
    private int cantObjetos;
    public AudioSource kobe;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider stackObj) {
        Object obj = stackObj.GetComponent<Object>();

        if (obj != null && obj.isStack)
        {
            cantObjetos++;
        }

        if (cantObjetos > 0) Invoke("DoIStop", 3);
    }

    void OnTriggerExit(Collider stackObj) {
        Object obj = stackObj.GetComponent<Object>();

        if (obj != null && obj.isStack)
        {
            cantObjetos--;
        }

        if (cantObjetos == 0) CancelInvoke("DoIStop");
    }
    

    public void Unparent()
    {
        gameObject.transform.parent = null;
        rb.constraints = RigidbodyConstraints.FreezePositionZ;
        rb.useGravity = true;
    }

    public void NewParent()
    {
        transform.rotation = Quaternion.identity;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        rb.useGravity = false;
    }

    public bool Stack()
    {
        return isStack;
    }

    private void DoIStop()
    {
        isStack = true;
        gameObject.layer = 9;
        thrown = false;
        rb.isKinematic = true;
        kobe.Play();
    }
}
