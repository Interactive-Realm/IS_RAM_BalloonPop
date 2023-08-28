using System.Collections.Generic;
using Postgrest.Models;
using Postgrest.Attributes;
using Newtonsoft.Json;

[Table("highscores")]
public class Highscore : BaseModel
{
    [PrimaryKey("user_id")]
    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [Column("score")]
    [JsonProperty("score")]
    public int Score { get; set; }
}

public class HighscoreWrapper
{
    public List<Highscore> Highscores { get; set; }
}