using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HexIA : MonoBehaviour
{
    // public float speedEnemy = 1;
   
    public float achicar = 0.1f;
    // public GameObject condicionDerrota;

    void Start()
    {
        
    }
    void Update()
    {
       // this.transform.localScale -= Vector3.one * Time.deltaTime * achicar;
        // this.transform.Translate(0, -speedEnemy * Time.deltaTime, 0); // es igual que poner this.transform.translate (Vector3.Down * speed * Time.deltaTime);
        this.transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * achicar;     //Achica el objeto en (x,x,x)
        
        
        if (transform.localScale.x <= 0.03f)            //Si el Objeto llega a la posicion 0.02 en X se destruye
        {
            Destroy(gameObject);
        }

    }


    /*void OnTriggerEnter2D(Collider2D col1)  //Solo funciona con objetos Trigger
    {
        Debug.Log("Se destruye Hexagono");
        Destroy(this.gameObject); 
    }*/
    void OnCollisionEnter2D(Collision2D colision2)
    {
        Debug.Log("Destrui Player");
        Destroy(gameObject);
      //  condicionDerrota.SetActive(true);
      // Tocar Enter para Volver al Menu Inicial <--- Generar el codigo necesario y que luego un if te lleve al cambio de Scena
      
    }
  
   // private void OnTriggerEnter(Collider other)
   // {
   //     Debug.Log("Se destruye Hexagono");
   //     Destroy(this.gameObject);
   // }

}