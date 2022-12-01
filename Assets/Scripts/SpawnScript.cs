using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] possibleEnimes;
    public int activeEnemies;

    private float timeToWait;

    private GameObject enemy;

    public Bacteria bacteria;
    public Fago fago;
    public Virus virus;

    void Start() 
    {
        StartCoroutine(generateEnemy());
    }

    void Update()
    {

    }

    private IEnumerator generateEnemy()
    {
        int rangeX = (int) (((transform.localScale.x + transform.position.x) / 2) - 1);
        int transformX = Random.Range(-rangeX, rangeX);

        enemy = possibleEnimes[Random.Range(0, possibleEnimes.Length)];
        activeEnemies++;

        Instantiate(enemy, new Vector3(transformX, transform.position.y, 0f), Quaternion.identity);

        if(ControladorPontuacao.Pontuacao >= 0 && ControladorPontuacao.Pontuacao <= 1000)
        {
            timeToWait = 2.5f;
            //Debug.Log("2 segundos");
            
            virus.chanceSoltarItemVida = 1;
            fago.chanceSoltarItemVida = 5;
            bacteria.chanceSoltarItemVida = 10;

            Debug.Log("A chance do virus soltar é 1");
            
        }
        if(ControladorPontuacao.Pontuacao > 1000 && ControladorPontuacao.Pontuacao <= 2000)
        {
            timeToWait = 2f;
            //Debug.Log("2 segundos");
            
            virus.chanceSoltarItemVida = 5;
            fago.chanceSoltarItemVida = 8;
            bacteria.chanceSoltarItemVida = 12;

            Debug.Log("A chance do virus soltar é 5");
        }
        if(ControladorPontuacao.Pontuacao > 2000 && ControladorPontuacao.Pontuacao <= 5000)
        {
            timeToWait = 1f;
            //Debug.Log("1 segundos");
            virus.chanceSoltarItemVida = 8;
            fago.chanceSoltarItemVida = 12;
            bacteria.chanceSoltarItemVida = 18;

            Debug.Log("A chance do virus soltar é 8");
        }
        if(ControladorPontuacao.Pontuacao > 5000 && ControladorPontuacao.Pontuacao <= 10000)
        {
            timeToWait = 0.8f;
            //Debug.Log("0,5 segundo");
            
            virus.chanceSoltarItemVida = 10;
            fago.chanceSoltarItemVida = 15;
            bacteria.chanceSoltarItemVida = 20;

            Debug.Log("A chance do virus soltar é 10");
        }
        if(ControladorPontuacao.Pontuacao > 10000)
        {
            timeToWait = 0.5f;
            //Debug.Log("0,5 segundo");
            
            virus.chanceSoltarItemVida = 15;
            fago.chanceSoltarItemVida = 20;
            bacteria.chanceSoltarItemVida = 25;

            Debug.Log("A chance do virus soltar é 15");
        }

        yield return new WaitForSeconds(timeToWait);

        yield return generateEnemy();
    }

}
