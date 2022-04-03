using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovPlayer : MonoBehaviour
{
    public float speed = 0.05f;
    public int contPuntos = 0;

    public float contadorTiempo;
    private int vida = 1;

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

    }
    void Update()
    {
        

        txtPuntajeFinal.text = "Has Obtenido: " + contPuntos.ToString() + " Puntos";
        txtTiempo.text = contadorTiempo.ToString("f1");
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
            StartCoroutine(EndGameRoutine());
        }

    }
        

    

    private void OnCollisionEnter2D(Collision2D collision) // Para colisiones con objetos solidos (sin activar trigger)
    {
        vida--;
        soundMorir.Play();
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // Para colisiones con objetos trigger (son transpasables pero colisionan)
    {
        if (vida > 0)
        {
            contPuntos++; // Suma puntos cada vez que atravieza el collider "Trigger" de un Hexagono sin chocar con sus lados visibles.
            soundPunto.Play();
        }
        
    }
    IEnumerator EndGameRoutine()
    {
       // this.gameObject.SetActive(false);

        condicionDerrota.SetActive(true);
        tiempoRegresoMenu.SetActive(true);
        cantPuntosObtenidos.SetActive(true);

        soundPunto.Pause();
        soundMorir.Pause();

        GetComponent<SpriteRenderer>().enabled = false;
        contadorTiempo += Time.deltaTime;


        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene("MainMenu");
        this.gameObject.SetActive(false);
    }

}
