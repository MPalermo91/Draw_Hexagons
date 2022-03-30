using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    public float speed = 0.05f;
    // public GameObject condicionDerrota;
    public float contPuntos;
    private int vida;

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Para colisiones con objetos solidos (sin activar trigger)
    {
        vida--;
         if (vida <= 0)
         {
             Debug.Log("Perder");
            // Destroy(this.gameObject);   //Destruye el objeto con el que colisiona con este objeto (menos los trigger)
            //      condicionDerrota.SetActive(true);
         }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Para colisiones con objetos trigger (son transpasables pero colisionan)
    {
          contPuntos++;
          Debug.Log("Suma 1");
        //      Destroy(this.gameObject);   //Destruye el Objeto Trigger que colisiona con This Object (en este caso el player)
        //      condicionDerrota.SetActive(true);
        //  }
    }

    
}
