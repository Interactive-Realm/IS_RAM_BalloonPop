using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HighscoreList : MonoBehaviour
{
    public GameObject HighscoreItemPrefab;
    public bool ShowWeeklyHighscores = true;
    public int NumberOfRows = 10;

    public void Start()
    {
        CreateHighscoreItems();
    }

    private async void CreateHighscoreItems()
    {
        // Get highscores
        List<UserHighscore> highscores = await GetHighscores();

        // Delete children
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));

        // Create highscore list items
        if (highscores != null)
        {
            for (int i = 0; i < highscores.Count; i++)
            {
                UserHighscore userHighscore = highscores[i];
                GameObject itemObject = Instantiate(HighscoreItemPrefab, transform);
                HighscoreItem item = itemObject.GetComponent<HighscoreItem>();

                string name = $"{i + 1}: {userHighscore.first_name} {userHighscore.last_name}";
                item.SetInformation(name, userHighscore.highscore, SupabaseClient.Instance.Auth.CurrentUser?.Id == userHighscore.user_id);
            }
        }

        // Resize to fit children
        ResizeParentToChildren();
    }

    private void ResizeParentToChildren()
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

    private async Task<List<UserHighscore>> GetHighscores()
    {
        if (ShowWeeklyHighscores)
        {
            return await SupabaseClient.GetWeeklyHighscores(NumberOfRows);
        }

        return await SupabaseClient.GetHighscores(NumberOfRows);
    }
}
