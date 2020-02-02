using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime;
    public float startingTime;
    private int showTime = 0;
    private int minutos = 0;
    private int segundos = 0;
    private string min = "";
    private string seg = "";
    public Canvas canvas;
    
    [SerializeField] Text countdownText = null;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        canvas.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        showTime = Convert.ToInt32(Math.Ceiling(currentTime));
        minutos = Convert.ToInt32(Math.Floor(currentTime / 60));
        segundos = showTime - (60 * minutos);
        if (minutos <= 0 && segundos >= 60)
        {
            minutos = 0;
            if (minutos > 0)
            {
                segundos = 0;
            }
        }
        if (minutos >= 0)
        {
            if (segundos >= 60)
            {
                minutos = 1;
                segundos = 0;
            }
            min = "" + minutos;
        }        
        if (segundos < 10)
        {
            seg = "0" + segundos;
        }
        else
        {
            seg = segundos.ToString();
        }
        countdownText.text = min + ":" + seg;//showTime.ToString("0");        
    }
}