using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Virus : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade;

    public int vidaTotal = 1;
    private int vida;
    public int dano;

    // Atribuindo pontos por matar os inimigos
    public int pontos;
    public GameObject cp;

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
        if(vida <= 0)
        {
            //GetComponent<Pontuacao>().pontuar(pontos);
            cp.GetComponent<Pontuacao>().pontuar(pontos);

            //Debug.Log(cp.GetComponent<Pontuacao>().pontuacao);

            Destroy(this.gameObject, 0f);
        }
    }

    public void tomaDano(int dano)
    {
        vida = vida - dano;
    }
}
