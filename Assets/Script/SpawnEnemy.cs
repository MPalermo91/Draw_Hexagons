using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject spawnEnemy;

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
            Instantiate(spawnEnemy.transform, new Vector3(0f, 0f, 0f), Quaternion.identity);     // Define el Objeto, El lugar, el giro del objeto)

        }
        if (rnd == 3)
        {
            Instantiate(spawnEnemy.transform, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, -90f));    // Define el Objeto, El lugar, el giro del objeto)

        }
        if (rnd == 5)
        {
            Instantiate(spawnEnemy.transform, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, -180f));    // Define el Objeto, El lugar, el giro del objeto)

        }
        if (rnd == 7)
        {
            Instantiate(spawnEnemy.transform, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 90f));    // Define el Objeto, El lugar, el giro del objeto)

        }
    }
    
}
