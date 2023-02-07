using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelInstrucoes;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirInstrucoes()
    {
        painelMenuInicial.SetActive(false);
        painelInstrucoes.SetActive(true);
    }
    public void FecharInstrucoes()
    {
        painelMenuInicial.SetActive(true);
        painelInstrucoes.SetActive(false);
    }
    public void SairJogo()
    {
        Debug.Log("sair do jogo");
        Application.Quit();
    }
}
