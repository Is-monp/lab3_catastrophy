using UnityEngine;
using TMPro; 

public class Jugando : MonoBehaviour
{
    public TMP_Text nombreText; 
    public TMP_Text puntajeText; 

    void Start()
    {
        string nombre = "vale"; // Ingresa el nombre que deseas mostrar
        int puntaje = 100; // Ingresa el puntaje que deseas mostrar

        nombreText.text = nombre;
        puntajeText.text = puntaje.ToString();
    }
}



