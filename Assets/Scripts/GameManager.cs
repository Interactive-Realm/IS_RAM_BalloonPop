using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Canvas _gameEnd;
    [SerializeField]
    private Timer time;
    [SerializeField]
    private Spwaner _spwaner;
    [SerializeField]
    private Points points;

    static int _higScore;

    void Update()
    {
        if(time.timeIsRunning == false)
        {
            _spwaner.gameObject.SetActive(false);
            _gameEnd.gameObject.SetActive(true);
        }
    }
}
