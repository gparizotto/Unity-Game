using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Conecta_semaforos : MonoBehaviour
{
    public TextMeshProUGUI scoreText, scoreText2;
    public TextMeshProUGUI maxSpeedText;
    public TextMeshProUGUI timeRemaining_text;
    public AudioSource buzina;

    bool passou1 = false, passou2 = false, passou3 = false;
    public int score = 0;

    public int vida = 3;
    
    public float speed;
    public float space;
    public bool perdeu = false;

    float timeRemaining = 3;

    int maxVel = 130, vel;

    int bateu = 0;

    public static event Action NoMoreLives;

    [SerializeField] Sons sons;
    [SerializeField] TrafficLightCollision semaforo1;
    [SerializeField] Semaforo2 semaforo2;
    [SerializeField] Semaforo3 semaforo3;
    [SerializeField] Semaforo4 semaforo4;
    [SerializeField] Semaforo5 semaforo5;
    [SerializeField] Semaforo6 semaforo6;
    [SerializeField] private Image img1, img2, img3;
    public GameObject max_speed_canva, time_remaining_canva, score_canva, speed_canva;
    //[SerializeField] Semaforo7 semaforo7;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speed = gameObject.GetComponent<Speed>().speed;
        bateu = gameObject.GetComponent<CarCollision>().count;
        space += gameObject.GetComponent<Speed>().space;

        if(space > 100 && !perdeu)
        {
            space = 0; 
            score += 100;
        }    


        if(bateu > 0){
            if(bateu == 1 && !passou1)
            {
                
                passou1 = true;
                vida--;
                buzina.Play();
                score -= 200;
            }
            else if(bateu == 2 && !passou2)
            {
                
                passou2 = true;
                vida--;
                buzina.Play();
                score -= 200;
            }
            else if(bateu == 3 && !passou3)
            {
                
                passou3 = true;
                vida--;
                buzina.Play();
                score -= 200;
            }

            if(vida == 2)
            {
                img3.enabled = false;
            }
            else if(vida == 1)
            {
                img2.enabled = false;
            }
            else if(vida == 0)
            {
                img1.enabled = false;
            }
            
        }

        vel = 3*((int) speed);


        // if(semaforo1.passou_verde || semaforo2.passou_verde || semaforo3.passou_verde || semaforo4.passou_verde || semaforo5.passou_verde || semaforo6.passou_verde)
        //     Debug.Log("verde");
        // if(semaforo2.passou_amarelo)
        //     Debug.Log("amarelo2");    
        // if(semaforo1.passou_verde || semaforo2.passou_verde || semaforo3.passou_verde || semaforo4.passou_verde || semaforo5.passou_verde || semaforo6.passou_verde)
        //     score += 100;
        if(semaforo1.passou_vermelho || semaforo2.passou_vermelho || semaforo3.passou_vermelho || semaforo4.passou_vermelho || semaforo5.passou_vermelho || semaforo6.passou_vermelho)
        {
            score -= 300;
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
            buzina.Play();
        }
        if(semaforo1.passou_amarelo || semaforo2.passou_amarelo || semaforo3.passou_amarelo || semaforo4.passou_amarelo || semaforo5.passou_amarelo || semaforo6.passou_amarelo)
            score -= 50;

        if(semaforo1.passou_verde || semaforo1.passou_amarelo || semaforo1.passou_vermelho)
        {
            maxSpeedText.text = "90";
            maxVel = 90;
        }
        if(semaforo2.passou_verde || semaforo2.passou_amarelo || semaforo2.passou_vermelho)
        {
            maxSpeedText.text = "110";
            maxVel = 120;
        }
        if(semaforo3.passou_verde || semaforo3.passou_amarelo || semaforo3.passou_vermelho)
        {
            maxSpeedText.text = "100";
            maxVel = 100;
        }
        if(semaforo4.passou_verde || semaforo4.passou_amarelo || semaforo4.passou_vermelho)
        {
            maxSpeedText.text = "90";
            maxVel = 90;
        }
        if(semaforo5.passou_verde || semaforo5.passou_amarelo || semaforo5.passou_vermelho)
        {
            maxSpeedText.text = "130";
            maxVel = 130;
        }
        if(semaforo6.passou_verde || semaforo6.passou_amarelo || semaforo6.passou_vermelho)
        {
            maxSpeedText.text = "120";      
            maxVel = 120;          
        }

        maxSpeedText.text = maxVel.ToString();

        if(timeRemaining >= 3 && timeRemaining <= 6)
            timeRemaining -= Time.deltaTime;
        else if(vel > maxVel && timeRemaining >= 0 && timeRemaining <= 3)
        {
            timeRemaining_text.text = timeRemaining.ToString("0");
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
            buzina.Play();
            timeRemaining = 6;
            timeRemaining_text.text = "";
        }

        if(vida == 0)
        {
            max_speed_canva.SetActive(false);
            score_canva.SetActive(false);
            time_remaining_canva.SetActive(false);
            speed_canva.SetActive(false);
            Time.timeScale = 0f;
            GameOverMenu.GameIsOver = true;
            if(GameOverMenu.GameIsOver)
                perdeu = true;
            else
                perdeu = false;    
            NoMoreLives?.Invoke();
        }

        scoreText.text = "Pontuação: " + score.ToString();  
        scoreText2.text = "Pontuação: " + score.ToString();  
    }
}
