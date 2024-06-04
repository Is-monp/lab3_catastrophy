using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Puntaje : MonoBehaviour
{
    private int score;  
    public Text scoreText; 
     void Start (){
         score = 0; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "moneda")
        {
            score +=10; 
            Debug.Log(score); 

        }

    }
   
   
}