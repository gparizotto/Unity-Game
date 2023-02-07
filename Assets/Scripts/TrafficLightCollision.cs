using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightCollision : MonoBehaviour
{
    public float timeRemaining;
    public int Vermelho = 1;

    public bool passou_vermelho = false;
    public bool passou_verde = false;
    public bool passou_amarelo = false;

    Light Green;
    Light Yellow;
    Light Red;

    Collider m_collider;

    void Start()
    {
        timeRemaining = 30f;
        m_collider = GetComponent<Collider>();
        m_collider.enabled = true;

        Green = GameObject.Find("Green").GetComponentInChildren<Light>();
        Yellow = GameObject.Find("Yellow").GetComponentInChildren<Light>();
        Red = GameObject.Find("Red").GetComponentInChildren<Light>();

    }

    void Update()
    {
        passou_amarelo = false;
        passou_verde = false;
        passou_vermelho = false;

        if(timeRemaining > 15) // verde - Vermelho -1
        {
            
            Vermelho = -1;
            timeRemaining -= Time.deltaTime;
            Red.intensity = 0;
            Yellow.intensity = 0;
            Green.intensity = 2;
        }
        else if (timeRemaining <= 15 && timeRemaining > 10) // amarelo - Vermelho -1
        {
            timeRemaining -= Time.deltaTime;
            Red.intensity = 0;
            Yellow.intensity = 2;
            Green.intensity = 0;
        }
        else if(timeRemaining <= 10 && timeRemaining > 0) // vermelho - Vermelho 1
        {
            Vermelho = 1;
            timeRemaining -= Time.deltaTime;
            Red.intensity = 2;
            Yellow.intensity = 0;
            Green.intensity = 0;
        }
        else
        {
            timeRemaining = 30;
        }

        //if(Vermelho == 1)
            m_collider.enabled = true;
        // else
        //     m_collider.enabled = false;    
    }

    private void OnTriggerEnter(Collider col)
    {
        
        if(timeRemaining <= 30 && timeRemaining > 15)
        {
            Debug.Log("Passouuu");
            passou_verde = true;
            passou_vermelho = false;
            passou_amarelo = false;
        }
        if(timeRemaining <= 15 && timeRemaining > 10)
        {
            passou_verde = false;
            passou_vermelho = false;
            passou_amarelo = true;
        }
        if(timeRemaining <= 10 && timeRemaining > 0)
        {
            passou_verde = false;
            passou_vermelho = true;
            passou_amarelo = false;
        }
    }
}
