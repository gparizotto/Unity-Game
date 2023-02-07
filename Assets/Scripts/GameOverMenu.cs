using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverUI;

    //public static bool GameIsOver = false;

    private void OnEnable()
    {
        Conecta_semaforos.NoMoreLives += EnableGameOverMenu;
        //GameIsOver = false;
    }

    private void OnDisable()
    {
        Conecta_semaforos.NoMoreLives -= EnableGameOverMenu;
        //GameIsOver = true;
    }

    public void EnableGameOverMenu()
    {
        gameOverUI.SetActive(true);
    }
    
    public void JogarNovamente()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Sample Scene");
    }

    public void CarregaMenu2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Sair2()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();
    }

}
