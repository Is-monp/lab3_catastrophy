using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Holder : MonoBehaviour
{
    public static Holder instance;
    public Transform Holder_Puntos;
    public GameObject Informacion;

    void Awake()
    {
        instance = this;
    }

    public void UpdateScores(List<KeyValuePair<string, int>> sortedScores)
    {
        
        Dictionary<string, int> combinedScores = new Dictionary<string, int>(); //diccionario temporal con lo nuevo y lo antiguo

        
        foreach (Transform child in Holder_Puntos) // Agrega puntuaciones existentes al diccionario temporal
        {
            Text textComponent = child.GetComponent<Text>();
            if (textComponent != null)
            {
                string playerName = textComponent.text.Split(':')[0].Trim(); // Obtener el nombre del jugador de la entrada existente
                int score = int.Parse(textComponent.text.Split(':')[1].Trim()); // Obtener el puntaje del jugador de la entrada existente
                combinedScores[playerName] = score; // Agregar la puntuación al diccionario combinado
            }
        }

        // Actualizar las puntuaciones existentes en el diccionario combinado
        foreach (KeyValuePair<string, int> entry in sortedScores)
        {
            if (combinedScores.ContainsKey(entry.Key))
            {
                combinedScores[entry.Key] = entry.Value; // Actualizar la puntuación existente en el diccionario combinado
            }
            else
            {
                combinedScores[entry.Key] = entry.Value; // Agregar la nueva puntuación al diccionario combinado
            }
        }

        // Crear nuevas entradas con las puntuaciones combinadas
        foreach (KeyValuePair<string, int> entry in combinedScores)
        {
            GameObject newEntry = Instantiate(Informacion, Holder_Puntos);
            newEntry.GetComponent<Text>().text = entry.Key + ": " + entry.Value.ToString();
        }
    }


}


