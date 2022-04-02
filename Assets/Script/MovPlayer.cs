using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MovPlayer : MonoBehaviour
{
    public float speed = 0.05f;
    public float contPuntos = 0;
    public float contadorTiempo;
    public bool destruiObjeto;
    private int vida = 1;

    public GameObject condicionDerrota;

    public Text txtPuntos;

    public AudioSource soundPunto;
    public AudioSource soundMorir;

    public void Start()
    {
        txtPuntos = this.GetComponent<Text>();
        // /* txtPuntos.text = contPuntos.ToString("00");*/
        contadorTiempo = 5f;
        condicionDerrota.SetActive(false);
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
            Destroy(this.gameObject);   //Destruye el objeto que colisiona con este objeto (menos los trigger)
        }
        for (float t = 0; destruiObjeto == true; t++)
        {
            contadorTiempo--;
            condicionDerrota.SetActive(true);

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
    }

    private void OnTriggerEnter2D(Collider2D collision) // Para colisiones con objetos trigger (son transpasables pero colisionan)
    {
        contPuntos += 1; // Suma puntos cada vez que atravieza el collider "Trigger" de un Hexagono sin chocar con sus lados visibles.
        soundPunto.Play();
    }


}
