using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("AudioManager Manager is NULL");

            return _instance;
        }
    }
    private void UIManagerStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.SignUp:

                break;

            case GameState.Login:

                break;
            case GameState.CountDown:

                break;
            case GameState.GameStart:

                break;

            case GameState.Playing:

                break;

            case GameState.Paused:

                break;

            case GameState.GameEnd:

                break;

            default:
                break;
        }
    }
    void Awake()
    {
        _instance = this;
        GameManager.OnGameStateChanged += UIManagerStateChange;
    }

    public AudioSource aSourceAM;

    public AudioMixer mixer;

    public AudioClip countdownBeep;
}
