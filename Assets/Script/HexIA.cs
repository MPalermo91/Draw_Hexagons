using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HexIA : MonoBehaviour
{
    // public float speedEnemy = 1;
   
    public float achicar = 0.2f;
    
 // public GameObject tiempoVolverAlMenu;
    public Text txtTiempo;

    void Start()
    {
        
        txtTiempo = this.GetComponent<Text>();
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


    
    void OnCollisionEnter2D(Collision2D colision2)
    {
        Debug.Log("Destrui Player");
        Destroy(gameObject);
    }
  
   

}