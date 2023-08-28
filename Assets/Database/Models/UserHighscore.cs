using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class UserHighscore
{
    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("highscore")]
    public int Highscore { get; set; }
}

public class UserHighscoreWrapper
{
    public List<UserHighscore> UserHighscores { get; set; }
}