using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade;

    public int vidaTotal = 3;
    private int vida;
    public int dano;

    // Atribuindo pontos por matar os inimigos
    public int pontos;
    public GameObject cp;
    
    // Start is called before the first frame update
    void Start()
    {
        pontos = 300;
        dano = 1;
        velocidade = 2;

        vida = vidaTotal;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <= 0)
        {
            // Pontuacao deveria vir aqui
            cp.GetComponent<Pontuacao>().pontuar(pontos);
            Destroy(this.gameObject, 0f);
        }
    }

    public void tomaDano(int dano)
    {
        vida = vida - dano;
    }
}
