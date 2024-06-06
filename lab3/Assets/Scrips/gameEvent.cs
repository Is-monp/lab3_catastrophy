using UnityEngine;

public class gameEvent : MonoBehaviour
{
    private ActualizaInfo actualizaInfo;

    void Start()

    {

        actualizaInfo = FindObjectOfType<ActualizaInfo>();

    }

    public void OnPlayerScore(string playerName, int score)

    {

        actualizaInfo.AddPlayerScore(playerName, score);

    }

}
