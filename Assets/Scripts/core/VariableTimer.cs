using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableTimer : MonoBehaviour
{
    public float actualTimeOfEvent;  // The actual time when the event should occur
    public float timerTime;          // The timer duration
    public bool started = false, finished = false;     // Flag indicating whether the timer has finished
    public string timeLeft;          // Zmienna przechowująca pozostały czas w formacie MM:SS

    private void Awake()
    {
        actualTimeOfEvent = float.PositiveInfinity;
    }

    public void StartTimer(float delay)
    {
        actualTimeOfEvent = Time.time + delay;
        timerTime = delay;  // Zapisujemy początkowy czas timera
        started = true;
        StartCoroutine(RunTimer());
    }

    public void ResetTimer()
    {
        finished = false;
    }

    private IEnumerator RunTimer()
    {  
        while (Time.time < actualTimeOfEvent)
        {
            // Obliczanie pozostałego czasu
            float remainingTime = actualTimeOfEvent - Time.time;
            
            // Konwersja na minuty i sekundy
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            
            // Formatowanie czasu do postaci MM:SS
            timeLeft = string.Format("{0:00}:{1:00}", minutes, seconds);
            
            yield return null;
        }
        
        finished = true;
        started = false;
        timeLeft = "00:00";
        actualTimeOfEvent = float.PositiveInfinity;
    }
}