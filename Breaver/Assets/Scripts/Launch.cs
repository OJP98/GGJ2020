using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Launch : MonoBehaviour
{

    [SerializeField] private float ratio = 2.5f;
    [SerializeField] private int minAngle = -5;
    [SerializeField] private int maxAngle = 60;
    [SerializeField] private int speedAngle = 100;


    [SerializeField] private Transform direction;
    [SerializeField] private Rigidbody thing;

    [SerializeField] private int maxForce = 100;
    [SerializeField] private int speedForce = 100;

    public Image progressFore;

    public Gradient gradient;

    private Chest center;
    private float currentAngle = 0;
    private float currentForce = 0;
    private int dirAngle = 1;
    private int dirForce = 1;

    private bool haveSomething = true;
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
            if (canAim)
                canAim = false;
            else
            {
                launch(direction.position - center.transform.position);
                haveSomething = false;
            }
                
        }

        if (haveSomething)
        {
            if (canAim)
            {
                currentAngle += Time.deltaTime * speedAngle * dirAngle;

                if (currentAngle >= maxAngle)
                {
                    dirAngle *= -1;
                    currentAngle = maxAngle;
                }
                else if (currentAngle <= minAngle)
                {
                    dirAngle *= -1;
                    currentAngle = minAngle;
                }

                direction.localPosition = new Vector3(ratio * Mathf.Cos(Mathf.Deg2Rad * currentAngle),
                    ratio * Mathf.Sin(Mathf.Deg2Rad * currentAngle),
                    0);
            } else
            {
                currentForce += Time.deltaTime * speedForce * dirForce;

                if (currentForce >= maxForce)
                {
                    dirForce *= -1;
                    currentForce = maxForce;
                }
                else if (currentForce <= 0)
                {
                    dirForce *= -1;
                    currentForce = 0;
                }

                float forcePercentage = currentForce / maxForce;
                progressFore.fillAmount = forcePercentage;
                progressFore.color = gradient.Evaluate(forcePercentage);
            }
        }
    }

    private void launch(Vector3 dir)
    {
        Debug.Log(dir);

        Rigidbody bullet = Instantiate(thing, center.transform.position, Quaternion.identity);
        //bullet.AddForce(dir * force);
    }
}
