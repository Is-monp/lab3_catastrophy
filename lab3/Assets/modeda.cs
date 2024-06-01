using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modeda : MonoBehaviour
{
    void Start()
    {
        
    }

   private void OnTriggerEnter2D(Collider2D other)
   {
    if (other.gameObject.tag == "cat_player")
    {
        other.gameObject.GetComponent<Agarrarmonedas>().agarrar();
        Destroy(gameObject); 
    }



   } 
}
