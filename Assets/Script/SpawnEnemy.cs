using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject spawnEnemyDown;
    public GameObject spawnEnemyUp;
    public GameObject spawnEnemyLeft;
    public GameObject spawnEnemyRight;

    void Start()
    {
        InvokeRepeating("Spawnear", 5, Random.Range(3, 5));
    }

    void Update()
    {
       
    }

    void Spawnear()
    {
        int rnd = Random.Range(0, 9);
        if(rnd == 1)
        {
            Instantiate(spawnEnemyDown.transform, new Vector3(0f, 0f, 0f), Quaternion.identity);     // Define el Objeto, El lugar, el giro del objeto)

        }
        if (rnd == 3)
        {
            Instantiate(spawnEnemyUp.transform, new Vector3(0f, 0f, 0f), Quaternion.identity);    // Define el Objeto, El lugar, el giro del objeto)

        }
        if (rnd == 5)
        {
            Instantiate(spawnEnemyLeft.transform, new Vector3(0f, 0f, 0f), Quaternion.identity);    // Define el Objeto, El lugar, el giro del objeto)

        }
        if (rnd == 7)
        {
            Instantiate(spawnEnemyRight.transform, new Vector3(0f, 0f, 0f), Quaternion.identity);    // Define el Objeto, El lugar, el giro del objeto)

        }
    }
    
}
