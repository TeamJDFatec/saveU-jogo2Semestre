using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text textoPontuacao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exibir()
    {
        this.gameObject.SetActive(true);
        textoPontuacao.text = "PONTUAÇÃO: " + ControladorPontuacao.Pontuacao;
        // Pausando o jogo quando a tela de game over for chamada, mas eu nao quero fazer isso
        //Time.timeScale = 0;
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
    }

    public void VoltarAoMenu()
    {
        // Aqui o jogo volta a correr normalmente depois do game over
        //Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
