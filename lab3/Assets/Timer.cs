using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText; // Asignar en el Inspector
    [SerializeField] private Button startButton; // Asignar en el Inspector

    private float timeElapsed;
    private int minutes, seconds, cents;
    private bool isTimerRunning = false;

    private void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartTimer);
        }
        else
        {
            Debug.LogError("Start Button no está asignado en el Inspector");
        }

        if (timerText == null)
        {
            Debug.LogError("Timer Text no está asignado en el Inspector");
        }
    }

    private void Update()
    {
        if (isTimerRunning && timerText != null)
        {
            timeElapsed += Time.deltaTime;
            minutes = (int)(timeElapsed / 60f);
            seconds = (int)(timeElapsed - minutes * 60f);
            cents = (int)((timeElapsed - (int)timeElapsed) * 100f);

            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
        }
    }

    private void StartTimer()
    {
        isTimerRunning = true;
    }
}
