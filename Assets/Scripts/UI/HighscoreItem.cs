using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreItem : MonoBehaviour
{
    public TMP_Text Username;
    public TMP_Text Highscore;

    public void SetInformation(string username, int highscore, bool currentUser)
    {
        Username.text = username;
        Highscore.text = Utils.FormatScore(highscore);

        if (currentUser)
        {
            Username.color = Color.green;
            Highscore.color = Color.green;
        }
    }
}
