using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovPlayer : MonoBehaviour
{
    public float speed = 0.05f;
    public float contPuntos = 0;
    public float contadorTiempo;
    public bool destruiObjeto;
    private int vida = 1;

    public GameObject condicionDerrota;
    public GameObject tiempoRegresoMenu;

    public Text txtPuntos;
    public Text txtTiempo;

    public AudioSource soundPunto;
    public AudioSource soundMorir;

    public void Start()
    {
        contadorTiempo = 5000;

        txtPuntos.GetComponent<Text>();
        txtPuntos.text = contPuntos.ToString("00");
        txtTiempo.GetComponent<Text>();
        txtTiempo.text = contadorTiempo.ToString("00");
        
        condicionDerrota.SetActive(false);
        tiempoRegresoMenu.SetActive(false);
        soundMorir.Pause();
        soundPunto.Pause();
    }
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

        if (vida <= 0)
        {
            // Destroy(this.gameObject);   //Destruye el objeto que colisiona con este objeto (menos los trigger)
            this.gameObject.SetActive(false);
        }
        for (float t = 0; destruiObjeto == true && t >= 5; t++)
        {
            contadorTiempo--;
            Debug.Log("Contador de tiempo: " + contadorTiempo);
            
            if (contadorTiempo <= 0)
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
        condicionDerrota.SetActive(true);
        tiempoRegresoMenu.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) // Para colisiones con objetos trigger (son transpasables pero colisionan)
    {
        contPuntos ++; // Suma puntos cada vez que atravieza el collider "Trigger" de un Hexagono sin chocar con sus lados visibles.
        Debug.Log("Score: "+ contPuntos);
        soundPunto.Play();
    }


}
