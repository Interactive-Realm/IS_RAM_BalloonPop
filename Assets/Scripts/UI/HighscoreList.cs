using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class HighscoreList : MonoBehaviour
{
    public GameObject HighscoreItemPrefab;

    public async void Start()
    {
        List<Profile> profiles = await SupabaseClient.GetTopTenHighscores();

        // Delete children
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        // Create highscore list items
        if (profiles != null)
        {
            Debug.Log(profiles.ToString());
            for (int i = 0; i < profiles.Count; i++)
            {
                Profile profile = profiles[i];

                GameObject itemObject = Instantiate(HighscoreItemPrefab, transform);
                HighscoreItem item = itemObject.GetComponent<HighscoreItem>();

                string name = $"{i + 1}: {profile.FirstName} {profile.LastName}";
                item.SetInformation(name, profile.Highscore, SupabaseClient.Instance.Auth.CurrentUser?.Id == profile.Id);
            }
        }
        

        // Resize to fit children
        ResizeParentToChildren();
    }

    public void ResizeParentToChildren()
    {
        RectTransform parentRectTransform = GetComponent<RectTransform>();
        float newHeight = 0f;

        // Calculate the combined height of all children
        foreach (RectTransform child in parentRectTransform)
        {
            if (child.gameObject.activeInHierarchy) // Only consider active children
            {
                newHeight += child.sizeDelta.y + child.anchoredPosition.y;
            }
        }

        newHeight += (parentRectTransform.childCount - 1) * 8;

        // Set parent's height to match the combined height of children
        Vector2 newSize = parentRectTransform.sizeDelta;
        newSize.y = newHeight;
        parentRectTransform.sizeDelta = newSize;
    }
}
