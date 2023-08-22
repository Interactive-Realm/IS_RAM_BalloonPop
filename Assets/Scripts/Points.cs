using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Points : MonoBehaviour
{
    public GameObject _points;
    public TextMeshProUGUI pointsText;
    bool timeIsRunning = false;
    private float gameTime = 45;
    // Start is called before the first frame update
    void Start()
    {
        timeIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeIsRunning)
        {
            
           if (gameTime > 0)
            {
                gameTime -= Time.deltaTime;
                Debug.Log(_points.GetComponent<Touch>()._points);
                DisplayPoints();
            }
            else
            {
                gameTime = 0;
                timeIsRunning = false;
            } 
        }
    }
    void DisplayPoints()
    {
        pointsText.text = _points.GetComponent<Touch>()._points.ToString();
    }
}
