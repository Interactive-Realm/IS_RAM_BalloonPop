using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldHandler : MonoBehaviour
{
    public TMP_InputField InputField;
    public TMP_Text FeedbackText;
    public string Text => InputField.text;
}
