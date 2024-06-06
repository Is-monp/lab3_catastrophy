using Photon.Pun;
using UnityEngine;

public class ActualizaInfo : MonoBehaviour
{
    private SistemaPuntos sistemaPuntos;
    private PhotonView photonView; // Declara la variable photonView

    void Start()
    {
        sistemaPuntos = FindObjectOfType<SistemaPuntos>();
        photonView = GetComponent<PhotonView>(); // Inicializa photonView
        if (photonView == null)
        {
            Debug.LogError("PhotonView component not found.");
        }
    }

    public void AddPlayerScore(string playerName, int score)
    {
        sistemaPuntos.AddScore(playerName, score);
        photonView.RPC("UpdateScoreboard", RpcTarget.All);
    }
}
