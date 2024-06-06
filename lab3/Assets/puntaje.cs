using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Puntaje : MonoBehaviourPunCallbacks
{
    private int puntaje;  

    void Start ()
    {
        puntaje = 0; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "moneda")
        {
            photonView.RPC("aumentcoin", RpcTarget.AllBuffered);
        }
    }

    [PunRPC]
    private void aumentcoin()
    {
        puntaje += 10; 
        Debug.Log(puntaje); 
    }
}
