using System;
using UnityEngine;

public class SignUpView : View
{
    public InputFieldHandler FirstNameInputField;
    public InputFieldHandler LastNameInputField;
    public InputFieldHandler PhoneInputField;
    public InputFieldHandler EmailInputField;
    public InputFieldHandler PasswordInputField;

    public void SignUp()
    {
        Debug.Log("Sign up started");
        try
        {
            SupabaseClient.SignUpUser(EmailInputField.Text, PasswordInputField.Text, PhoneInputField.Text, FirstNameInputField.Text, LastNameInputField.Text, 0);
            Debug.Log("Signed up");
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
