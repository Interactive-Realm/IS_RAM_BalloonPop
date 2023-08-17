using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwaner : MonoBehaviour
{
    
    [SerializeField]
    private GameObject prefab;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private float currentTime;

    private Vector3 viewPos;

    
    void Start()
    {
        currentTime = 0;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = prefab.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2; 
        objectHeight = prefab.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y -1 - objectHeight);
    }

    void LateUpdate()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            SelectWave();
        }
    }
    void SelectWave()
    {
        currentTime = 0.5f;
        Vector3 test = new Vector3(Random.Range(screenBounds.x,- screenBounds.x), -screenBounds.y, 0);
        Instantiate(prefab, test, Quaternion.identity);  
    }

}
