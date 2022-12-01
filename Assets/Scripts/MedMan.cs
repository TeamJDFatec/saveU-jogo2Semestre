using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedMan : MonoBehaviour
{
    public float velocidade;

    public GameObject tiro;
    public Transform pivo;

    private Coracao coracao;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        ControladorPontuacao.Pontuacao = 0;

        GameObject coracaoObject = GameObject.FindGameObjectWithTag("Coracao");
        coracao = coracaoObject.GetComponent<Coracao>();
    }

    // Update is called once per frame
    void Update()
    {
        mover();
        atira();
    }

    void mover()
    {
        float direcionamento = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
        transform.Translate(direcionamento, 0f, 0f);

        var bordaEsquerda = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        var bordaDireita = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;

        transform.position = new Vector2(
            // Função Mathf.Clamp permite limitar o valor da posição do personagem no max e min, no caso as bordas.
            Mathf.Clamp(transform.position.x, bordaEsquerda, bordaDireita),
            transform.position.y
        );


    }

    void atira()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(tiro, pivo.position, transform.rotation);
        }
    }

    public void Inativo()
    {
        // Deixa o player inativo na cena. Será usado quando a tela game over for chamada
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ItemVida"))
        {
            ItemVida itemVida = collider.GetComponent<ItemVida>();

            if (coracao.vida + itemVida.quantidadeVidas >= coracao.vidaTotal)
            {
                coracao.vida = coracao.vidaTotal;
            }
            else
            {
                coracao.vida = itemVida.quantidadeVidas;
            }
        }
    }
}
