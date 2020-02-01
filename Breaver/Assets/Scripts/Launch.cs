using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour
{

    [SerializeField] private float ratio = 2.5f;
    [SerializeField] private int minAngle = -5;
    [SerializeField] private int maxAngle = 60;
    [SerializeField] private int speed = 100;
    [SerializeField] private Transform direction;
    [SerializeField] private GameObject thing;

    private Chest center;
    private float currentAngle = 0;
    private int dir = 1;
    private bool canAim = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        center = GetComponentInChildren<Chest>();

        direction.localPosition = new Vector3(ratio * Mathf.Cos(Mathf.Deg2Rad * currentAngle),
            ratio * Mathf.Sin(Mathf.Deg2Rad * currentAngle),
            0);
    }

    private void Update() {

        if (Input.anyKeyDown) {
            //transform.eulerAngles = new Vector3(0, transform.localEulerAngles.y + 180, 0);
            canAim = false;

            launch(direction.position - center.transform.position);
        }

        if (canAim)
        {
            currentAngle += Time.deltaTime * speed * dir;

            if (currentAngle >= maxAngle)
            {
                dir *= -1;
                currentAngle = maxAngle;
            }
            else if (currentAngle <= minAngle)
            {
                dir *= -1;
                currentAngle = minAngle;
            }

            direction.localPosition = new Vector3(ratio * Mathf.Cos(Mathf.Deg2Rad * currentAngle),
                ratio * Mathf.Sin(Mathf.Deg2Rad * currentAngle),
                0);
        }


    }

    private void launch(Vector3 dir)
    {
        Debug.Log(dir);



    }
}
