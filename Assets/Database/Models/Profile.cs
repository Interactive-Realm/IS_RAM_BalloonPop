using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Postgrest.Models;
using Postgrest.Attributes;

[Table("profiles")]
public class Profile : BaseModel
{
    [PrimaryKey("user_id")]
    public string Id { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }

    [Column("highscore")]
    public int Highscore { get; set; }
}
