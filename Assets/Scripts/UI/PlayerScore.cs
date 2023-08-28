using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public TMP_Text Score;
    public TMP_Text Highscore;

    async void Start()
    {
        Score.text = "000000"; // TODO - Set score

        if (SupabaseClient.Instance.Auth.CurrentUser == null)
        {
            Highscore.text = "0000000";
        }
        else
        {
            // TODO - Maybe move this to a manager, and also the Score.text above
            UserHighscore userHighscore = await SupabaseClient.GetUserWeeklyHighscore();
            Highscore.text = FormatScore(userHighscore.Highscore);
        }
    }

    private string FormatScore(int value, int minLength = 6)
    {
        string str = value.ToString();
        if (str.Length < minLength) {
            int paddingLength = minLength - str.Length;
            string padding = new string('0', paddingLength);
            return padding + str;
        }

        return str;
    }
}
