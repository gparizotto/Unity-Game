using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conecta_semaforos : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxSpeedText;
    public TextMeshProUGUI timeRemaining_text;
    public int score = 0;

    public int vida = 3;
    
    public float speed;

    float timeRemaining = 3;

    int maxVel = 60, vel;

    [SerializeField] TrafficLightCollision semaforo1;
    [SerializeField] Semaforo2 semaforo2;
    [SerializeField] Semaforo3 semaforo3;
    [SerializeField] Semaforo4 semaforo4;
    [SerializeField] Semaforo5 semaforo5;
    [SerializeField] Semaforo6 semaforo6;
    [SerializeField] private Image img1, img2, img3;
    //[SerializeField] Semaforo7 semaforo7;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speed = gameObject.GetComponent<Speed>().speed;
        vel = 3*((int) speed);


        // if(semaforo1.passou_verde || semaforo2.passou_verde || semaforo3.passou_verde || semaforo4.passou_verde || semaforo5.passou_verde || semaforo6.passou_verde)
        //     Debug.Log("verde");
        // if(semaforo2.passou_amarelo)
        //     Debug.Log("amarelo2");    
        if(semaforo1.passou_verde || semaforo2.passou_verde || semaforo3.passou_verde || semaforo4.passou_verde || semaforo5.passou_verde || semaforo6.passou_verde)
            score += 100;
        if(semaforo1.passou_vermelho || semaforo2.passou_vermelho || semaforo3.passou_vermelho || semaforo4.passou_vermelho || semaforo5.passou_vermelho || semaforo6.passou_vermelho)
        {
            score -= 200;
            if(vida == 3)
            {
                img3.enabled = false;
            }
            if(vida == 2)
            {
                img2.enabled = false;
            }
            if(vida == 1)
            {
                img1.enabled = false;
            }
            vida--;

        }
        if(semaforo1.passou_amarelo || semaforo2.passou_amarelo || semaforo3.passou_amarelo || semaforo4.passou_amarelo || semaforo5.passou_amarelo || semaforo6.passou_amarelo)
            score -= 50;

        if(semaforo1.passou_verde || semaforo1.passou_amarelo || semaforo1.passou_vermelho)
        {
            maxSpeedText.text = "50";
            maxVel = 50;
        }
        if(semaforo2.passou_verde || semaforo2.passou_amarelo || semaforo2.passou_vermelho)
        {
            maxSpeedText.text = "70";
            maxVel = 70;
        }
        if(semaforo3.passou_verde || semaforo3.passou_amarelo || semaforo3.passou_vermelho)
        {
            maxSpeedText.text = "40";
            maxVel = 40;
        }
        if(semaforo4.passou_verde || semaforo4.passou_amarelo || semaforo4.passou_vermelho)
        {
            maxSpeedText.text = "100";
            maxVel = 100;
        }
        if(semaforo5.passou_verde || semaforo5.passou_amarelo || semaforo5.passou_vermelho)
        {
            maxSpeedText.text = "80";
            maxVel = 80;
        }
        if(semaforo6.passou_verde || semaforo6.passou_amarelo || semaforo6.passou_vermelho)
        {
            maxSpeedText.text = "60";      
            maxVel = 60;          
        }

        if(timeRemaining >= 3 && timeRemaining <= 6)
            timeRemaining -= Time.deltaTime;
        else if(vel > maxVel && timeRemaining >= 0 && timeRemaining <= 3)
        {
            timeRemaining_text.text = "TEMPO RESTANTE: " + timeRemaining.ToString("0.0");
            timeRemaining -= Time.deltaTime;
        }
        else if(vel <= maxVel)
        { 
            timeRemaining = 3;
            timeRemaining_text.text = "";
        }
        
        if(timeRemaining <= 0)
        {
            if(vida == 3)
            {
                img3.enabled = false;
            }
            if(vida == 2)
            {
                img2.enabled = false;
            }
            if(vida == 1)
            {
                img1.enabled = false;
            }
            vida--;
            timeRemaining = 6;
            timeRemaining_text.text = "";
        }


        scoreText.text = "Score: " + score.ToString();  
    }
}
