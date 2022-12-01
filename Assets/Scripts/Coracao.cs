using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coracao : MonoBehaviour
{
    public int vidaTotal = 5;
    public int vida;

    private GameOver gameover;

    private MedMan player;

    // Start is called before the first frame update
    void Start()
    {
        vida = vidaTotal;

        /*GameObject objetoGameOver = GameObject.FindGameObjectWithTag("TelaGameOver");
        gameover = objetoGameOver.GetComponent<GameOver>();*/

        GameObject objetoPlayer = GameObject.FindGameObjectWithTag("Player");
        player = objetoPlayer.GetComponent<MedMan>();

        //gameover.Esconder();
    }

    // Update is called once per frame
    void Update()
    {
        if(vida < 0)
        {
            vida = 0;
            // Deixa o player imóvel
            player.Inativo();
            // GameOver
            //gameover.Exibir();
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
        if(other.gameObject.layer == 8)
        {
            tomaDano(other.GetComponent<Fago>().dano);
        }
        if(other.gameObject.layer == 9)
        {
            return;
        }
        Destroy(other.gameObject, 0f);
    }
}
