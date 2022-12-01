using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text textoPontuacao;
    public bool inGameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Exibir()
    {
        this.gameObject.SetActive(true);
        
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(0, 0);

        textoPontuacao.text = "PONTUAÇÃO: " + ControladorPontuacao.Pontuacao;
        // Pausando o jogo quando a tela de game over for chamada, mas eu nao quero fazer isso
        //Time.timeScale = 0;
        inGameOver = true;
    }

    public void Esconder()
    {
        inGameOver = false;
        this.gameObject.SetActive(false);
    }

    public void VoltarAoMenu()
    {
        // Aqui o jogo volta a correr normalmente depois do game over
        //Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene("MainScene");
    }
}
