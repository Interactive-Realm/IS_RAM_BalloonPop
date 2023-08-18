using UnityEngine;
using TMPro;

public class FormFeedbackText : MonoBehaviour
{
    public TMP_Text Text;

    public void Start()
    {
        ResetText();
    }

    public void SetText(string text)
    {
        Text.SetText(text);
    }

    public void ResetText()
    {
        Text.SetText("");
    }
}
