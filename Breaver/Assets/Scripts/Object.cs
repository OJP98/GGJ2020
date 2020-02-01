using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
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
}
