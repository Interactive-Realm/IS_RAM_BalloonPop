using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
}

public enum GameState
{
        MainMenu,
        Start,
        Playing,
        Paused,
        Won,
        Lost,
}
