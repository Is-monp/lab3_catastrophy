using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    
   
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag== "cat_player")
        {
            Destroy(this.gameObject);
        }
    }
}