using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coracao : MonoBehaviour
{
    private int vidaTotal = 5;
    public int vida;

    //private Virus virus;
    //private Bacteria bacteria;

    // Start is called before the first frame update
    void Start()
    {
        vida = vidaTotal;
        //virus = GetComponent<Virus>();
        //bacteria = GetComponent<Bacteria>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vida < 0)
        {
            // GameOver
        }
    }

    void tomaDano(int dano)
    {
        vida = vida - dano;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == 6)
        {
            tomaDano(other.GetComponent<Virus>().dano);
        }
        if(other.gameObject.layer == 7)
        {
            tomaDano(other.GetComponent<Bacteria>().dano);
        }
        Destroy(other.gameObject, 0f);
    }
}
