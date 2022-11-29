using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float velocidade;
    public Rigidbody2D rb;
    private float tempoParaDestruir = 2f;

    // Causando algum dano
    public int dano = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector2.up * velocidade;
        Destroy(this.gameObject, tempoParaDestruir);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 6)
        {
            other.GetComponent<Virus>().tomaDano(dano);
        }
        if(other.gameObject.layer == 7)
        {
            other.GetComponent<Bacteria>().tomaDano(dano);
        }
        Destroy(this.gameObject, 0f);
    }
    
}
