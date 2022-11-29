using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public int pontuacao;
    public TextMesh texto;

    // Start is called before the first frame update
    void Start()
    {
        pontuacao = 0;
        texto = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = "Pontuação: " + pontuacao;
    }

    public void pontuar(int pontos)
    {
        pontuacao = pontuacao + pontos;
    }
}
