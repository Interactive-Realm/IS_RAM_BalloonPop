using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private void Start()
    {
        HideImmediateChildren();
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void SwitchView(GameObject gameObject)
    {
        HideImmediateChildren();
        gameObject.SetActive(true);
    }

    public void HideImmediateChildren()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.SetActive(false);
        }
    }
}
