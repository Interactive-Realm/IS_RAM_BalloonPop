using System;
using System.Security.Cryptography.X509Certificates;
using Supabase.Gotrue.Exceptions;
using UnityEngine;
using UnityEngine.UI;

public class SignUpView : View
{
    [Header("Inputs")]
    public InputFieldHandler FirstName;
    public InputFieldHandler LastName;
    public InputFieldHandler Phone;
    public InputFieldHandler Email;
    public InputFieldHandler Password;

    [Header("Feedback")]
    public FormFeedbackText Feedback;

    public void SignUp()
    {
        ResetFeedback();

        if (HasError()) return;

        try
        {
            SupabaseClient.SignUpUser(Email.Text, Password.Text, Phone.Text, FirstName.Text, LastName.Text, 0);
            ResetInput();
            Debug.Log("Logged in");
        }
        catch (GotrueException e)
        {
            Feedback.SetText(e.Message);
        }
    }

    private bool HasError()
    {
        bool error = false;

        if (FirstName.Text == "")
        {
            FirstName.SetFeedback("Mangler fornavn");
            error = true;
        }
        if (LastName.Text == "")
        {
            LastName.SetFeedback("Mangler efternavn");
            error = true;
        }
        if (Phone.Text == "")
        {
            Phone.SetFeedback("Mangler mobilnummer");
            error = true;
        }
        if (Email.Text == "")
        {
            Email.SetFeedback("Mangler email");
            error = true;
        }
        if (Password.Text == "")
        {
            Password.SetFeedback("Mangler kodeord");
            error = true;
        }
        else if (Password.Text.Length < 6)
        {
            Password.SetFeedback("Kodeord skal være mindst 6 karaktere lang");
            error = true;
        }

        return error;
    }

    private void ResetFeedback()
    {
        FirstName.ResetFeedback();
        LastName.ResetFeedback();
        Phone.ResetFeedback();
        Email.ResetFeedback();
        Password.ResetFeedback();
        Feedback.ResetText();
    }

    private void ResetInput()
    {
        FirstName.ResetInput();
        LastName.ResetInput();
        Phone.ResetInput();
        Email.ResetInput();
        Password.ResetInput();
        Feedback.ResetText();
    }
}
