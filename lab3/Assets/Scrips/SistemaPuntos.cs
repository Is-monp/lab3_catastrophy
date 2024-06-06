using UnityEngine;
using System.Collections.Generic;
using Photon.Pun;

public class SistemaPuntos : MonoBehaviourPun
{

    private Dictionary<string, int> playerScores = new Dictionary<string, int>(); // Contiene nombre sala y puntos partida 

    public void AddScore(string playerName, int score) // método para agregar información a diccionario 

    {

        if (playerScores.ContainsKey(playerName))

        {

            playerScores[playerName] += score; // si el nombre de la sala ya existe, se actualiza puntaje 

        }
        else

        {
            playerScores[playerName] = score; // si no existe, se agrega 

        }

    }

    [PunRPC]

    public void UpdateScoreboard()

    {

        // Ordena de mayor a menor 

        List<KeyValuePair<string, int>> sortedScores = new List<KeyValuePair<string, int>>(playerScores);

        sortedScores.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

        // Actualiza el Holder 

        Holder.instance.UpdateScores(sortedScores);

    }

}
