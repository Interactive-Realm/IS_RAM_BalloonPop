using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class View : MonoBehaviour
{
    private RectTransform _rectTransform;

    public void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void UpdateUI()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
    }
}
