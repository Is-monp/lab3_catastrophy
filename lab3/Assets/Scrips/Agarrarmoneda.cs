using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Agarrarmoneda : MonoBehaviour
{
    public TMP_Text puntos; // Campo para el objeto TMP_Text
    public int monedas; 

    void Start()
    {
        if (puntos == null)
        {
            Debug.LogError("El campo 'puntos' no está asignado en el Inspector.");
        }
    }

    void Update()
    {
        if (puntos != null)
        {
            puntos.text = monedas.ToString();
        }
        else
        {
            Debug.LogError("El campo 'puntos' es nulo. Asegúrate de asignarlo en el Inspector.");
        }
    }

    public void agarrar ()
    {
        monedas += 10; 
    }
}

