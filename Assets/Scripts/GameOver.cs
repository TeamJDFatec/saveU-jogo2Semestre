using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public InGame jogando;

    public Text textoPontuacao;
    public Text textoMelhorPontuacao;
    public bool inGameOver;

    public AudioSource som;

    // Start is called before the first frame update
    void Start()
    {
        som.Play();
    }

    public void Exibir()
    {
        this.gameObject.SetActive(true);
        inGameOver = true;

        //som.Play();
        jogando.Start();

        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(0, 0);

        textoPontuacao.text = "PONTUAÇÃO: " + ControladorPontuacao.Pontuacao;
        textoMelhorPontuacao.text = "MELHOR PONTUAÇÃO: " + ControladorPontuacao.MelhorPontuacao;
        //Debug.Log("Melhor pontuação: " + ControladorPontuacao.MelhorPontuacao);
        // Pausando o jogo quando a tela de game over for chamada, mas eu nao quero fazer isso
        //Time.timeScale = 0;
    }

    public void Esconder()
    {
        inGameOver = false;
        this.gameObject.SetActive(false);
        som.Stop();

        jogando.Start();
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
