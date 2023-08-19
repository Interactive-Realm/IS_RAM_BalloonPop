using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Supabase.Gotrue;
using Postgrest.Responses;
using UnityEngine;
using Client = Supabase.Client;
using Postgrest.Exceptions;
using Newtonsoft.Json;

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

    public static async Task<Session> SignUpUser(string email, string password, string phone, string firstName, string lastName, int highscore)
    {
        // Create user metadata
        SignUpOptions options = new SignUpOptions
        {
            FlowType = Constants.OAuthFlowType.Implicit,
            Data = new Dictionary<string, object>
            {
                { "email", email },
                { "phone", phone },
                { "first_name", firstName },
                { "last_name", lastName },
                { "highscore", highscore }
            }
        };

        // Sign up
        return await Instance.Auth.SignUp(email, password, options);
    }

    public static async Task<Session?> SignInUser(string email, string password)
    {
        return await Instance.Auth.SignInWithPassword(email, password);
    }

    public static async void SignOutUser()
    {
        await Instance.Auth.SignOut();
    }

    public static async Task<List<Profile>> GetTopTenHighscores()
    {
        Task<BaseResponse> rpc = Instance.Rpc("get_top_ten_highscores", null);
        rpc.AsUniTask().GetAwaiter();
        try
        {
            await rpc;
        }
        catch (PostgrestException)
        {
            throw;
        }

        if (rpc.IsCompleted)
        {
            return JsonConvert.DeserializeObject<List<Profile>>(rpc.Result.Content);
        }

        return null;
    }

    public static async void SetHighscore(int highscore)
    {
        await Instance
            .From<Profile>()
            .Where(x => x.Id == Instance.Auth.CurrentSession.User.Id)
            .Set(x => x.Highscore, highscore)
            .Update();
    }
}
