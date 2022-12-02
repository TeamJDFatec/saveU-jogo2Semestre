using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControladorPontuacao
{
    private static int pontuacao;


    public static int Pontuacao
    {
        get
        {
            return pontuacao;
        }
        set
        {
            pontuacao = value;
            if(pontuacao < 0)
            {
                pontuacao = 0;
            }
            Debug.Log("Pontuação atualizada para: " + Pontuacao);

            if(pontuacao > MelhorPontuacao)
            {
                MelhorPontuacao = pontuacao;
            }
        }
    }

    public static int MelhorPontuacao
    {
        get
        {
            int recorde = PlayerPrefs.GetInt("recorde", 0);
            return recorde;
        }
        set
        {
            if(value > MelhorPontuacao)
            {
                PlayerPrefs.SetInt("recorde", value);
            }
        }
    }
}
