using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    
    [SerializeField]
    private float gameTime;
    public bool timeIsRunning = false;
    public TextMeshProUGUI timeText;

    void Start()
    {

        timeText.text = "Tid: ";
    }

    void Update()
    {
        if(timeIsRunning)
        {
            
           if (gameTime > 0)
            {
                gameTime -= Time.deltaTime;
                
                DisplayTime(gameTime);
            }
            else
            {
                Debug.Log("Time Out!");
                gameTime = 0;
                timeIsRunning = false;
                GameManager.Instance.UpdateGameState(GameState.GameEnd);
            } 
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = "Tid: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

