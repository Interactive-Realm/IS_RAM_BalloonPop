using System;
using TMPro;
using UnityEngine;

public class SignInView : View
{
    public InputFieldHandler EmailInputField;
    public InputFieldHandler PasswordInputField;

    public void SignIn()
    {
        try
        {
            SupabaseClient.SignInUser(EmailInputField.Text, PasswordInputField.Text);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
