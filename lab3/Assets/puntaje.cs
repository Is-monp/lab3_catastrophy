using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Puntaje : MonoBehaviour
{
    private int puntaje;  
   
     void Start (){
         puntaje = 0; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "moneda")
        {
            puntaje +=10; 
            Debug.Log(puntaje); 

        }

    }
   
   
}