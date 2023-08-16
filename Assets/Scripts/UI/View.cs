using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class View : MonoBehaviour
{
    public void Hide()
    {
        enabled = false;
    }

    public void Show()
    {
        enabled = true;
    }
}
