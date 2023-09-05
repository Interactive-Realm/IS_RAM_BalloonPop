using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveGameplay : MonoBehaviour
{
    // Script references
    [SerializeField]
    private Balloon balloonScript;


    [SerializeField]
    private float time;
    [SerializeField]
    private float slowSpawnInterval;
    [SerializeField]
    private float fasterSpawnInterval;
    [SerializeField]
    private float fastestSpawnInterval;

    public float slowBalloonSpawnCount;
    public float fasterBalloonSpawnCount;
    public float fastestBalloonSpawnCount;
    public float slowSpeed;
    public float fasterSpeed;
    public float fastestSpeed;
    public float waveTime1;
    public float waveTime2;


    [SerializeField]
    private GameObject balloonPrefab;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public float currentTime;

    private Vector3 viewPos;

    

    public float currentBalloonsSpawnedCount = 0;

    public bool slow;
    public bool faster;
    public bool fastest;

    public float countdownTimer;
    public float currCountdownValue;
    public TextMeshProUGUI countdownText;


    private void Start()
    {

        balloonScript.speed = slowSpeed;
        //spawnFactor


        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = balloonPrefab.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = balloonPrefab.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        waveTime1 = 10;
        slowSpawnInterval = waveTime1 / slowBalloonSpawnCount;
        fasterSpawnInterval = waveTime1 / fasterBalloonSpawnCount;
        fastestSpawnInterval = waveTime2 / fastestBalloonSpawnCount;

    }

    private void Update()
    {
        time += Time.deltaTime;

        if ((time > 10 && time < 20) || (time > 30 && time < 40))
        {
            balloonScript.speed = fasterSpeed;
            if (faster)
            {
                Debug.Log("faster");
                StartCoroutine(SpawnBalloonsFaster(fasterSpawnInterval, fasterBalloonSpawnCount));
                faster = false;
                slow = true;
            }

        }
        else if (time > 40)
        {
            balloonScript.speed = fastestSpeed;
            if (fastest)
            {
                Debug.Log("fastest");
                StartCoroutine(SpawnBalloonsFastest(fastestSpawnInterval, fastestBalloonSpawnCount));
                fastest = false;
            }
        }
        else
        {
            balloonScript.speed = slowSpeed;
            if (slow)
            {
                Debug.Log("slow");
                StartCoroutine(SpawnBalloonsSlow(slowSpawnInterval, slowBalloonSpawnCount));
                slow = false;
                faster = true;
            }
        }
        

        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y - 1 - objectHeight);
    }

    



    IEnumerator SpawnBalloonsSlow(float spawnInterval, float balloonCount)
    {
        
        for (int i = 0; i < balloonCount; i++)
        {
            Vector3 test = new Vector3(Random.Range(screenBounds.x, -screenBounds.x), -screenBounds.y, 0);
            Instantiate(balloonPrefab, test, Quaternion.identity);
            currentBalloonsSpawnedCount++;
            yield return new WaitForSeconds(spawnInterval);
        }
        
    }
    IEnumerator SpawnBalloonsFaster(float spawnInterval, float balloonCount)
    {

        for (int i = 0; i < balloonCount; i++)
        {
            Vector3 test = new Vector3(Random.Range(screenBounds.x, -screenBounds.x), -screenBounds.y, 0);
            Instantiate(balloonPrefab, test, Quaternion.identity);
            currentBalloonsSpawnedCount++;
            yield return new WaitForSeconds(spawnInterval);
        }

    }
    IEnumerator SpawnBalloonsFastest(float spawnInterval, float balloonCount)
    {

        for (int i = 0; i < balloonCount; i++)
        {
            Vector3 test = new Vector3(Random.Range(screenBounds.x, -screenBounds.x), -screenBounds.y, 0);
            Instantiate(balloonPrefab, test, Quaternion.identity);
            currentBalloonsSpawnedCount++;
            yield return new WaitForSeconds(spawnInterval);
        }

    }
}
