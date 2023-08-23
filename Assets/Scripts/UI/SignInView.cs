using System;
using Supabase.Gotrue.Exceptions;
using UnityEngine;

public class SignInView : View
{
    [Header("Inputs")]
    public InputFieldHandler Email;
    public InputFieldHandler Password;

    [Header("Feedback")]
    public FormFeedbackText Feedback;

    public async void SignIn()
    {
        ResetFeedback();

        if (HasError()) return;

        try
        {
            await SupabaseClient.SignInUser(Email.Text, Password.Text);
            ResetInput();
            Debug.Log("Logged In");
            GameManager.Instance.UpdateGameState(GameState.GameStart);
        }
        catch (GotrueException e)
        {
            Debug.Log(e.Message);
        }
    }

    private bool HasError()
    {
        bool error = false;

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

        UpdateUI();

        return error;
    }

    private void ResetFeedback()
    {
        Email.ResetFeedback();
        Password.ResetFeedback();
        Feedback.ResetText();
    }

    private void ResetInput()
    {
        Email.ResetInput();
        Password.ResetInput();
        Feedback.ResetText();
    }
}
