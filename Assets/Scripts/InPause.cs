using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InPause : MonoBehaviour
{

    public void PausarJogo()
    {
        Time.timeScale = 0;
    }

    public void ContinuarJogo()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Exibir()
    {
        this.gameObject.SetActive(true);
        
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMin = new Vector2(0, 0);
        rectTransform.offsetMax = new Vector2(0, 0);
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
        
    }

    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
