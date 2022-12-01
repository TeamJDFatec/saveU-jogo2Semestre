using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraVida : MonoBehaviour
{
    public GameObject[] vacinas;

    public void ExibirVida(int vidas)
    {
        for (int i = 0; i < this.vacinas.Length; i++)
        {
            if (i < vidas)
            {
                this.vacinas[i].SetActive(true);
            }
            else
            {
                this.vacinas[i].SetActive(false);
            }
        }
    }

}
