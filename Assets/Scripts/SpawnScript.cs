using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] possibleEnimes;
    public int activeEnemies;

    private float timeToWait;

    private GameObject enemy;

    void Start() 
    {
        //InvokeRepeating("GenerateEnemy", 1.5f, 2f);

        StartCoroutine(generateEnemy());
    }

    void Update()
    {

    }

    /*void GenerateEnemy()
    {
        int rangeX = (int) (((transform.localScale.x + transform.position.x) / 2) - 1);
        int transformX = Random.Range(-rangeX, rangeX);

        //Debug.Log(transformX);

        enemy = possibleEnimes[Random.Range(0, possibleEnimes.Length)];
        activeEnemies++;

        Instantiate(enemy, new Vector3(transformX, transform.position.y, 0f), Quaternion.identity);
    }*/

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
            Debug.Log("2 segundos");
        }
        if(ControladorPontuacao.Pontuacao > 1000 && ControladorPontuacao.Pontuacao <= 2000)
        {
            timeToWait = 2f;
            Debug.Log("1,5 segundos");
        }
        if(ControladorPontuacao.Pontuacao > 2000)
        {
            timeToWait = 1f;
            Debug.Log("1 segundos");
        }

        yield return new WaitForSeconds(timeToWait);

        yield return generateEnemy();
    }

}
