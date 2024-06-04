using Photon.Pun;
using UnityEngine;

public class ActualizaInfo : MonoBehaviour

{
    private Sistema_Puntos sistemaPuntos;

    void Start()
    {
        sistemaPuntos = FindObjectOfType<Sistema_Puntos>();
    }

    public void AddPlayerScore(string playerName, int score)
    {
        sistemaPuntos.AddScore(playerName, score);
        photonView.RPC("UpdateScoreboard", RpcTarget.All);
    }
}

}
