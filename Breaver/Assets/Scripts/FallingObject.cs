using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    //public FallingObjectType type;
    private ObjectPull pool;

    public void SetPool(ObjectPull p) {
        pool = p;
    }

    public void Delete() {
        pool.ReturnToPool(this.gameObject);
    }
}
