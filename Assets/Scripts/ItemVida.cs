using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{
    public int quantidadeVidas;

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
