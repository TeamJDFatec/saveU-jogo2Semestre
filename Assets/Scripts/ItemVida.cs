using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{
    public int quantidadeVidas;
    
    private float velocidade;
    private Rigidbody2D rb;

    void Start()
    {
        velocidade = 5;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * velocidade;
    }

    public int QuantidadeVidas
    {
        get 
        {
            return this.quantidadeVidas;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

}
