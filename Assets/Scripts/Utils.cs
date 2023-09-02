using System;

public class Utils
{
    public static string FormatScore(int value, int minScoreLength = 6)
    {
        string str = value.ToString();
        if (str.Length < minScoreLength)
        {
            int paddingLength = minScoreLength - str.Length;
            string padding = new string('0', paddingLength);
            return padding + str;
        }

        return str;
    }

    public static string GetFormattedDate(DateTime date)
    {
        return date.ToString("yyyy-MM-dd");
    }
}


