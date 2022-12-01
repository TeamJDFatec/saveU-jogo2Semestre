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
        vida = 0;

        /*GameObject objetoGameOver = GameObject.FindGameObjectWithTag("TelaGameOver");
        gameover = objetoGameOver.GetComponent<GameOver>();*/

        GameObject objetoPlayer = GameObject.FindGameObjectWithTag("Player");
        player = objetoPlayer.GetComponent<MedMan>();

        //gameover.Esconder();
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(vida < 0)
        {
            // a vida igual a zero aqui estava dando problema para chamar o game over, já que ele estava sendo chamado sempre que a vida ficava igual a 0, e no nosso caso, tem que ser menor que zero para ele perder.
            // vida = 0;
            // Deixa o player imóvel
            //player.Inativo();

            // GameOver
            //gameover.Exibir();
        }*/
    }

    void tomaDano(int dano)
    {
        vida = vida - dano;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(vida < 0)
        {
            player.Inativo();
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else
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
        }
        Destroy(other.gameObject, 0f);
    }
}
