using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private InPause inPause;
    private GameOver gameOver;
    private Coracao coracao;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
        GameObject pauseObject = GameObject.FindGameObjectWithTag("TelaPause");
        inPause = pauseObject.GetComponent<InPause>();

        inPause.Esconder();

        GameObject gameOverObject = GameObject.FindGameObjectWithTag("TelaGameOver");
        gameOver = gameOverObject.GetComponent<GameOver>();

        gameOver.Esconder();

        GameObject coracaoObject = GameObject.FindGameObjectWithTag("Coracao");
        coracao = coracaoObject.GetComponent<Coracao>();


    }

    // Update is called once per frame
    void Update()
    {
        if (coracao.vida < 0)
        {
            coracao.vida = 0;
            gameOver.Exibir();
        }

        if (!gameOver.inGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                inPause.Exibir();
                inPause.PausarJogo();
            }
        }
    }
}
