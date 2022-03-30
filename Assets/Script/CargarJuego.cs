using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarJuego : MonoBehaviour
{
    
    public void IrAlJuego()
    {
        //Cambia de Escena <- Se debe agregar libreria de comandos de Escenas 
        SceneManager.LoadScene("GameScene");   //El numero entre parentisis corresponde a la escena que vamos a iniciar (por orden en Build Setting o por Nombre pero entre comillas (ej: "GameScene"))
    }
  
}
