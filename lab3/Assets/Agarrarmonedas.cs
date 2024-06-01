using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Agarrarmonedas : MonoBehaviour
{
    public Text puntos;  
    public int monedas; 
    void Start()
    {
        
    }

    void Update()
    {
        puntos.text = monedas.ToString(); 

        
    }

    public void agarrar () 
    {
        monedas += 10;
        

    }
}
