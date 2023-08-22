using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// Game States Enum
public enum GameState
{
    SignUp,
    Login,
    GameStart,
    Playing,
    Paused,
    GameEnd,
}

// Game Manager
public class GameManager : MonoBehaviour
{
    // Creates an instance of Game Manager
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("Game Manager is NULL");

            return _instance;
        }
    }

    // GameState Variables
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;


    [SerializeField]
    private Canvas _gameEnd;
    [SerializeField]
    private Timer time;
    [SerializeField]
    private Spawner spawner;
    [SerializeField]
    private Points points;

    static int _higScore;

    void Awake()
    {
        // Define instance reference & make it indestructable
        _instance = this;
        DontDestroyOnLoad(this.gameObject); 
    }

    void Update()
    {
        if(time.timeIsRunning == false)
        {
            spawner.gameObject.SetActive(false);
            _gameEnd.gameObject.SetActive(true);
        }
    }


    void Start()
    {
        //Game Initial State
        UpdateGameState(GameState.SignUp);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.SignUp:
                HandleSignUp();
                break;

            case GameState.Login:
                HandleLogin();
                break;

            case GameState.GameStart:
                HandleStartRound();
                break;

            case GameState.Playing:
                HandlePlayingGame();
                break;

            case GameState.Paused:
                HandlePauseGame();
                break;

            case GameState.GameEnd:
                break;

            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }


    public void HandleSignUp()
    {

    }

    public void HandleLogin()
    {

    }

    public void HandleStartRound()
    {
        
    }

    public void HandlePlayingGame()
    {
        Time.timeScale = 1f;
    }

    public void HandlePauseGame()
    {
        Time.timeScale = 0f;
    }
}


