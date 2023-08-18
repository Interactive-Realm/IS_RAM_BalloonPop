using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldHandler : MonoBehaviour
{
    public TMP_InputField InputField;
    public FormFeedbackText FeedbackText;
    public string Text => InputField.text;

    public void SetFeedback(string text)
    {
        FeedbackText.SetText(text);
    }

    public void ResetFeedback()
    {
        FeedbackText.ResetText();
    }

    public void ResetInput()
    {
        InputField.text = "";
        ResetFeedback();
    }
}
