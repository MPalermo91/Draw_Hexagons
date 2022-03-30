using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestObj : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Se destruye Hexagono");
        Destroy(other.gameObject);
    }

}
