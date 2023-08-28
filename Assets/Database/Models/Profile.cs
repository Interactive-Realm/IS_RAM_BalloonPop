using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Postgrest.Models;
using Postgrest.Attributes;
using static UnityEditor.Progress;
using Newtonsoft.Json;

[Table("profiles")]
public class Profile : BaseModel
{
    [PrimaryKey("user_id")]
    [JsonProperty("user_id")]
    public string UserId { get; set; }

    [Column("email")]
    [JsonProperty("email")]
    public string Email { get; set; }

    [Column("phone")]
    [JsonProperty("phone")]
    public string Phone { get; set; }

    [Column("first_name")]
    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    [JsonProperty("last_name")]
    public string LastName { get; set; }
}

public class ProfileWrapper
{
    public List<Profile> Profiles { get; set; }
}