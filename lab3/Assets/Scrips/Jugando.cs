using UnityEngine;

public class Jugando : MonoBehaviour
{
    private GameEvent gameEvent;

    void Start()
    {
        gameEvent = FindObjectOfType<GameEvent>();
    }

    // Este método se llama cuando un jugador gana puntos
    void OnPlayerAction()
    {
        string playerName = "Player1"; // Ejemplo: nombre del jugador
        int pointsEarned = 10; // Ejemplo: puntos ganados
        gameEvent.OnPlayerScore(playerName, pointsEarned);
    }
}
