using System;
using Supabase.Gotrue;
using UnityEngine;
using Client = Supabase.Client;

public class SupabaseClient
{
    private static string SUPABASE_URL = "https://ddzsyoprxvtzmszkkjap.supabase.co";
    private static string SUPABASE_PUBLIC_KEY = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImRkenN5b3ByeHZ0em1zemtramFwIiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTIxMjUwNDMsImV4cCI6MjAwNzcwMTA0M30.LblAPe5fhfeSAQ1YFDqpHLddgsvn6fpoacr7AgsEmBY";
    private static readonly Client _instance;
    public static Client Instance => _instance;

    static SupabaseClient()
    {
        if (_instance == null)
        {
            _instance = new Client(SUPABASE_URL, SUPABASE_PUBLIC_KEY);
            _instance.InitializeAsync().Wait();
        }
    }

    public static async void SignUpUser(string email, string password, string phone, string firstName, string lastName, int highscore)
    {
        try
        {
            Session session = await Instance.Auth.SignUp(email, password);
            Profile profile = new Profile
            {
                Id = session.User.Id,
                FirstName = firstName,
                LastName = lastName,
                Highscore = highscore
            };
            await Instance.From<Profile>().Insert(profile);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static async void SignInUser(string email, string password)
    {
        try
        {
            Session session = await Instance.Auth.SignInWithPassword(email, password);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static async void SignOutUser()
    {
        try
        {
            await Instance.Auth.SignOut();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public static async void SetHighscore(int highscore)
    {
        try
        {
            await Instance
                .From<Profile>()
                .Where(x => x.Id == Instance.Auth.CurrentSession.User.Id)
                .Set(x => x.Highscore, highscore)
                .Update();
        }
        catch (Exception e)
        {
            throw;
        }
    }
}
