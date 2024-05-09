using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public string time_played;
    public TMP_Text timer;
    float elapsedTime = 0f; 

    void Start()
    { 
    }

    void Update()
    {
        // Increment elapsed time
        elapsedTime += Time.deltaTime;

        // Convert to minutes and seconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        time_played = $"{minutes:D2}:{seconds:D2}";
        // Display formatted time (e.g., "01:23")
        timer.text = time_played;
    }
}
