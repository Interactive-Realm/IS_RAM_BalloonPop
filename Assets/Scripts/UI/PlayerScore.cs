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
            Profile profile = await SupabaseClient.GetUserProfile();
            Highscore.text = profile.Highscore.ToString();
        }
    }
}
