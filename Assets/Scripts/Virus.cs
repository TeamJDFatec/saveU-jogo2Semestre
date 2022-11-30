using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Virus : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade;

    public int vidaTotal = 1;
    public int vida;
    public int dano;

    // Atribuindo pontos por matar os inimigos
    public int pontos;

    // Start is called before the first frame update
    void Start()
    {
        pontos = 200;
        dano = 2;
        velocidade = 4;

        vida = vidaTotal;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tomaDano(int dano)
    {
        vida = vida - dano;
    }

    public void Destruir()
    {
        ControladorPontuacao.Pontuacao = ControladorPontuacao.Pontuacao + pontos;
        Destroy(this.gameObject);
    }
}
