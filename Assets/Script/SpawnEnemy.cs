using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float modifGiro;

    public GameObject spawnEnemy;

    SpriteRenderer spr;

    
    void Start()
    {
        InvokeRepeating("Spawnear", 3, Random.Range(1, 3));
        spr = spawnEnemy.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        modifGiro += Time.deltaTime;
    }

    void Spawnear()
    {
        int rnd = Random.Range(0, 6);
        Debug.Log(rnd);
        if(rnd == 1)
        {
            Instantiate(spawnEnemy.transform, new Vector3(0f, 0f, 0f), Quaternion.identity);     // Define el Objeto, El lugar, el giro del objeto)
            modifGiro = 0;
        }
        if (rnd == 2)
        {
            Instantiate(spawnEnemy.transform, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, -90f));    // Define el Objeto, El lugar, el giro del objeto)
            modifGiro = 0;
        }
        if (rnd == 3)
        {
            Instantiate(spawnEnemy.transform, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, -180f));    // Define el Objeto, El lugar, el giro del objeto)
            modifGiro = 0;
        }
        if (rnd == 4)
        {
            Instantiate(spawnEnemy.transform, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 90f));    // Define el Objeto, El lugar, el giro del objeto)
            modifGiro = 0;
        }
        if (rnd == 5)
        {
            Instantiate(spawnEnemy.transform, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 90f * Time.deltaTime));    // Define el Objeto, El lugar, el giro del objeto)
            spr.color = Random.ColorHSV();
        }
    }
    
}
