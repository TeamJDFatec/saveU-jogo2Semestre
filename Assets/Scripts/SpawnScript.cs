using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] possibleEnimes;
    public int activeEnemies;


    private GameObject enemy;

    void Start() 
    {
        InvokeRepeating("GenerateEnemy", 1.5f, 2f);
    }

    void Update()
    {

    }

    void GenerateEnemy()
    {
        int rangeX = (int) (((transform.localScale.x + transform.position.x) / 2) - 1);
        int transformX = Random.Range(-rangeX, rangeX);

        //Debug.Log(transformX);

        enemy = possibleEnimes[Random.Range(0, possibleEnimes.Length)];
        activeEnemies++;

        Instantiate(enemy, new Vector3(transformX, transform.position.y, 0f), Quaternion.identity);
    }

}
