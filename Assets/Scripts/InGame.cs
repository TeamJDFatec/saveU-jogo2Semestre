using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{

    public Text textoPontuacao;
    public BarraVida barraVida;

    private Coracao coracao;

    void Start() 
    {
        this.coracao = GameObject.FindGameObjectWithTag("Coracao").GetComponent<Coracao>();
    }

    // Update is called once per frame
    void Update()
    {
        this.textoPontuacao.text = "Pontuação: " + ControladorPontuacao.Pontuacao.ToString();
        this.barraVida.ExibirVida(this.coracao.vida);
    }
}
