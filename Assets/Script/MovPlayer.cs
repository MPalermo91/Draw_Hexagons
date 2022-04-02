using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovPlayer : MonoBehaviour
{
    public float speed = 0.05f;
    public float contPuntos = 0;

    public int contadorTiempo;
    private int vida = 1;

    public bool destruiObjeto;

    public GameObject condicionDerrota;
    public GameObject tiempoRegresoMenu;
    public GameObject cantPuntosObtenidos;

    public Text txtPuntos;
    public Text txtTiempo;
    public Text txtPuntajeFinal;

    public AudioSource soundPunto;
    public AudioSource soundMorir;

    public void Start()
    {
        contadorTiempo = 0;

        txtPuntos.GetComponent<Text>();
        txtTiempo.GetComponent<Text>();
        
        condicionDerrota.SetActive(false);
        tiempoRegresoMenu.SetActive(false);
        cantPuntosObtenidos.SetActive(false);

        soundMorir.Pause();
        soundPunto.Pause();
    }
    void Update()
    {
        txtPuntajeFinal.text = "Has Obtenido: " + cantPuntosObtenidos.ToString() + " Puntos";
        txtTiempo.text = contadorTiempo.ToString();
        txtPuntos.text = "Score: " + contPuntos.ToString();

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
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

        if (vida <= 0)
        {
            Destroy(this.gameObject);   //Destruye el objeto que colisiona con este objeto (menos los trigger)
            //this.gameObject.SetActive(false);
        }
        for (int t = 0; destruiObjeto == true; t++)
        {
            //PuedeContarTiempo(true);
            contadorTiempo++;
            condicionDerrota.SetActive(true);
            tiempoRegresoMenu.SetActive(true);
            cantPuntosObtenidos.SetActive(true);

            if (contadorTiempo >= 50)
            {
                destruiObjeto = false;
                SceneManager.LoadScene("MainMenu");
            }
        }
       

    }

    private void OnCollisionEnter2D(Collision2D collision) // Para colisiones con objetos solidos (sin activar trigger)
    {
        vida--;
        soundMorir.Play();
        destruiObjeto = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Para colisiones con objetos trigger (son transpasables pero colisionan)
    {
        contPuntos ++; // Suma puntos cada vez que atravieza el collider "Trigger" de un Hexagono sin chocar con sus lados visibles.
        soundPunto.Play();
    }


}
