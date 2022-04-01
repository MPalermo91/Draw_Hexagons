using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MovPlayer : MonoBehaviour
{
    public float speed = 0.05f;
    // public GameObject condicionDerrota;
    public float contPuntos;
    private int vida = 1;
    // private int tempVolverAlMenu = 5;
    public Text txtPuntos;

    public void Start()
    {
        txtPuntos = this.GetComponent<Text>();
    }
    void Update()
    {
        txtPuntos.text = contPuntos.ToString("0000");

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
            Destroy(this.gameObject);   //Destruye el objeto que colisiona con este objeto (menos los trigger)
            Debug.Log("Perdiste, tus puntos totales son: " + contPuntos);
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // Para colisiones con objetos trigger (son transpasables pero colisionan)
    {
          contPuntos+= 10; // Suma puntos cada vez que atravieza un Hexagono sin chocar con sus lados visibles.
    }

    
}
