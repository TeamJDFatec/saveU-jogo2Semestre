using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InPause : MonoBehaviour
{

    public InGame jogando;

    public bool pausado;
    public AudioSource som;

    public void PausarJogo()
    {
        Time.timeScale = 0;
    }

    public void ContinuarJogo()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;

        pausado = false;
        jogando.Start();
    }

    public void Exibir()
    {
        pausado = true;
        this.gameObject.SetActive(true);
        som.Play();

        jogando.Start();
        
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(0, 0);
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
        pausado = false;
        som.Stop();

        jogando.Start();
        
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
