using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Creates an instance of UI Manager
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("UI Manager is NULL");

            return _instance;
        }
    }



    private void Awake()
    {
        //UI Manager Reference
        _instance = this;

        GameManager.OnGameStateChanged += UIManagerStateChange;
    }

    public void UIManagerStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.SignUp:
                break;
            case GameState.Login:
                break;
            case GameState.CountDown:
                HandleCountDown();
                break;
            case GameState.GameStart:
                HandleStartGame();
                break;
            case GameState.Paused:
                break;
            case GameState.GameEnd:
                break;

            default:
                break;
        }
    }

    public void HandleCountDown()
    {
        StartCoroutine(CountDown(countdownValue));
    }
    void HandleStartGame()
    {
        countdownText.text = "";
    }

    public float countdownValue;
    public float currCountdownValue;
    public TextMeshProUGUI countdownText;

    public IEnumerator CountDown(float countdownValue)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0)
        {
            countdownText.text = currCountdownValue.ToString();
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        GameManager.Instance.UpdateGameState(GameState.GameStart);
    }

}
