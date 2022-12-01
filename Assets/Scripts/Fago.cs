using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fago : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidade;

    public int vidaTotal = 2;
    public int vida;
    public int dano;

    // Atribuindo pontos por matar os inimigos
    public int pontos;

    [SerializeField]
    [Range(0, 100)]
    private float chanceSoltarItemVida;

    [SerializeField]
    private ItemVida itemVidaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        pontos = 400;
        dano = 3;
        velocidade = 3;

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
        SoltarItemVida();
        Destroy(this.gameObject);
    }

    private void SoltarItemVida()
    {
        float chanceAleatoria = Random.Range(0f, 100f);

        if (chanceAleatoria <= this.chanceSoltarItemVida) 
        {
            //Soltar o item de vida
            Instantiate(this.itemVidaPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.itemVidaPrefab, 3f);
        }
    }
}
