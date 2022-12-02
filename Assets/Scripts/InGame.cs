using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public GameOver gameOver;
    public InPause pause;

    public Text textoPontuacao;
    public BarraVida barraVida;

    private Coracao coracao;

    public AudioSource som;

    public void Start() 
    {
        this.coracao = GameObject.FindGameObjectWithTag("Coracao").GetComponent<Coracao>();

        if(gameOver.inGameOver || pause.pausado)
        {
            som.Pause();
        }
        else
        {
            som.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.textoPontuacao.text = "Pontuação: " + ControladorPontuacao.Pontuacao.ToString();
        this.barraVida.ExibirVida(this.coracao.vida);
    }
}
