using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkinGround: MonoBehaviour
{
    public static bool isGrounded;
    private void OnTriggerEnter2D(Collider2D collision) //el player est� en el suelo.
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision) //el player no est� en el suelo
    {
        isGrounded= false;
    }
}
