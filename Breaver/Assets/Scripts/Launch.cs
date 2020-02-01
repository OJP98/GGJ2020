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

    [SerializeField] private int maxForce = 100;
    [SerializeField] private int speedForce = 100;

    [SerializeField] private GameObject holder;

    public Canvas canvas;
    public Image progressFore;

    public Gradient gradient;

    private Chest center;
    private float currentAngle = 0;
    private float currentForce = 0;
    private int dirAngle = 1;
    private int dirForce = 1;

    private bool haveSomething = false;
    private bool canAim = true;
    

    void Start()
    {
        center = GetComponentInChildren<Chest>();

        direction.localPosition = new Vector3(ratio * Mathf.Cos(Mathf.Deg2Rad * currentAngle),
            ratio * Mathf.Sin(Mathf.Deg2Rad * currentAngle),
            0);

        canvas.enabled = false;
        direction.gameObject.SetActive(false);
    }

    private void Update() {
        /*
        if (Input.GetButtonDown("Jump")) {
            if (canAim)
                canAim = false;
            else
            {
                launch(direction.position - center.transform.position);
                haveSomething = false;
            }  
        }*/
        

        if (holder.transform.childCount > 0)
            haveSomething = true;
        else
            haveSomething = false;


        if (haveSomething)
        {
            if (canAim)
            {
                direction.gameObject.SetActive(true);
                canvas.enabled = false;

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

                if (Input.GetButtonDown("Jump")) canAim = false;

            }
            else
            {
                canvas.enabled = true;

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

                if (Input.GetButtonDown("Jump")) launch(direction.position - center.transform.position, forcePercentage);
            }
        }
        else {
            direction.gameObject.SetActive(false);
            canvas.enabled = false;
        }
    }

    private void launch(Vector3 dir, float forcePercentage)
    {
        Rigidbody thing = holder.transform.GetChild(0).GetComponent<Rigidbody>();
        thing.GetComponent<Object>().Unparent();
        

        thing.AddForce(dir * maxForce * forcePercentage);
        canAim = true;
    }
}
