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
        Dictionary<string, Text> existingScores = new Dictionary<string, Text>(); // Store existing score Text components by player name

        // Collect existing scores into a dictionary
        foreach (Transform child in Holder_Puntos)
        {
            Text textComponent = child.GetComponent<Text>();
            if (textComponent != null)
            {
                string playerName = textComponent.text.Split(':')[0].Trim();
                existingScores[playerName] = textComponent;
            }
        }

        // Update or create new entries with the combined scores
        foreach (KeyValuePair<string, int> entry in sortedScores)
        {
            if (existingScores.ContainsKey(entry.Key))
            {
                // Update existing entry
                existingScores[entry.Key].text = entry.Key + ": " + entry.Value.ToString();
            }
            else
            {
                // Create new entry
                GameObject newEntry = Instantiate(Informacion, Holder_Puntos);
                newEntry.GetComponent<Text>().text = entry.Key + ": " + entry.Value.ToString();
            }
        }
    }
}