using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Postgrest.Exceptions;
using Supabase.Gotrue;
using Supabase.Gotrue.Exceptions;
using UnityEditor.PackageManager;
using UnityEngine;
using Client = Supabase.Client;

public class SupabaseClient
{
    private static string SUPABASE_URL = "";
    private static string SUPABASE_PUBLIC_KEY = "";
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
            UserInfo userInfo = new UserInfo
            {
                Id = session.User.Id,
                FirstName = firstName,
                LastName = lastName,
                Highscore = highscore
            };
            await Instance.From<UserInfo>().Insert(userInfo);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public static async void SignInUser(string email, string password)
    {
        try
        {
            Session session = await Instance.Auth.SignInWithPassword(email, password);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public static async void SignOutUser()
    {
        await Instance.Auth.SignOut();
    }

    public static async void SetHighscore(int highscore)
    {
        await Instance
            .From<UserInfo>()
            .Where(x => x.Id == Instance.Auth.CurrentSession.User.Id)
            .Set(x => x.Highscore, highscore)
            .Update();
    }

    public static async void GetUserFullName()
    {
       
    }
}
