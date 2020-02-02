using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform center;
    public Transform direction;
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.parent.forward.z);
        if (transform.parent.forward.z == -1)
            transform.localEulerAngles = new Vector3(0, 180, (180 / Mathf.PI) * Mathf.Atan2(center.position.y - direction.position.y, center.position.x - direction.position.x));
        else if (transform.parent.forward.z == 1)
            transform.localEulerAngles = new Vector3(0, 0, (180 / Mathf.PI) * Mathf.Atan2(center.position.y - direction.position.y, center.position.x - direction.position.x));
    }
}
