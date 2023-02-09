using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI;
    public AudioSource gameOverEffect;

    public static bool GameIsOver = false;

    void Start()
    {
        gameOverEffect.playOnAwake = false;
    }

    private void OnEnable()
    {
        Time.timeScale = 1f;
        Conecta_semaforos.NoMoreLives += EnableGameOverMenu;
       // gameOverEffect.Play();
        //GameIsOver = false;
    }

    private void OnDisable()
    {
        //Time.timeScale = 1f;
        GameIsOver = false;
        Conecta_semaforos.NoMoreLives -= EnableGameOverMenu;
        //GameIsOver = true;
    }

    public void EnableGameOverMenu()
    {
//        gameOverEffect.Play();
        gameOverUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    
    public void JogarNovamente()
    {
        //GameIsOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Sample Scene");
    }

    public void CarregaMenu2()
    {
        //GameIsOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Sair2()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }

}
