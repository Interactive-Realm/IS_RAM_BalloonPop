using System;
using System.Collections.Generic;

[Serializable]
public class UserHighscore
{
    public string user_id;
    public string first_name;
    public string last_name;
    public int highscore;
}

[Serializable]
public class UserHighscoreWrapper
{
    public List<UserHighscore> Items;
}