using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public TMP_Text Score;
    public TMP_Text Highscore;
    public int MinScoreLength = 6;

    async void Start()
    {
        Score.text = "SET ME"; // TODO - Set score

        if (SupabaseClient.IsUserSignedIn())
        {
            Highscore.text = new string('0', MinScoreLength);
        }
        else
        {
            UserHighscore userHighscore = await SupabaseClient.GetUserWeeklyHighscore();
            Highscore.text = Utils.FormatScore(userHighscore.highscore, MinScoreLength);
        }
    }
}
