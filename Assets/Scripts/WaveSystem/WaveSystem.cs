using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]

public class EnemyCount
{
    public string enemyType;
    public int count;
}

[System.Serializable]
public class WaveData
{
    public List<EnemyCount> enemyCounts = new List<EnemyCount>(); // Dictionary yerine List
    public float enemySpawnCooldown;
    public float timeforwinningwave;
}
public class WaveSystem : MonoBehaviour
{
    public Transform playertransform;
    public List<WaveData> waveDatas = new List<WaveData>();
    public List<GameObject> enemyTypes = new List<GameObject>(); 
    
    public int currentWave = 0;
    float timerforspawnenemy = 0;
    float timerforwave = 0;
    public TextMeshProUGUI timertext;
    bool iswaveclear = false;
    public Button buttonToMarket;

    void Start()
    {
        //Debug.Log($"Available Enemy Types: {string.Join(", ", enemyTypes.ConvertAll(e => e.name))}");

        CreateWave();
        buttonToMarket.gameObject.SetActive(false);
    }

    void Update()
    {
     
        timerforspawnenemy += Time.deltaTime;
        timerforwave += Time.deltaTime; 
        UpdateTimerText();
        
        if (currentWave < waveDatas.Count && timerforspawnenemy > waveDatas[currentWave].enemySpawnCooldown)
        {
            CreateWave();
        }

        CheckForWave();
        
    }

   void CreateWave()
{
    WaveData currentWaveData = waveDatas[currentWave];

    foreach (var enemyData in currentWaveData.enemyCounts)
    {
        GameObject enemyPrefab = enemyTypes.Find(e => e.name == enemyData.enemyType);
        if (enemyPrefab != null)
        {
            for (int i = 0; i < enemyData.count; i++)
            {
                Vector3 spawnPosition = GetSpawnPosition();
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    timerforspawnenemy = 0;
}

    Vector3 GetSpawnPosition()
    {
        float randomx, randomy;
        bool isInsideCameraView;

        do
        {
            randomx = UnityEngine.Random.Range(-15f, 15f);
            randomy = UnityEngine.Random.Range(-13f, 13f);

            float camLeft = playertransform.position.x - 12f;
            float camRight = playertransform.position.x + 12f;
            float camBottom = playertransform.position.y - 8f;
            float camTop = playertransform.position.y + 8f;

            isInsideCameraView = (randomx > camLeft && randomx < camRight) &&
                                 (randomy > camBottom && randomy < camTop);
        }
        while (isInsideCameraView);
        return new Vector3(randomx, randomy, 0);
    }

    void CheckForWave()
    {
        if (currentWave < waveDatas.Count && timerforwave >= waveDatas[currentWave].timeforwinningwave) 
        {
            currentWave++;
            iswaveclear = true;
            timerforwave = 0;
        }
    }
    
    void EndTheWave()
    {
        timertext.text = "WAVE CLEAR";
        SceneManager.LoadScene("Inventory");

        //buttonToMarket.gameObject.SetActive(true);
        //Time.timeScale = 0;   // baska sekil cözmemiz lazim
    }

    void UpdateTimerText()
    {
        if (iswaveclear)
        {
            EndTheWave();
        }
        else
        {
            int minutes = Mathf.FloorToInt(timerforwave / 60);
            int seconds = Mathf.FloorToInt(timerforwave % 60);
            timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

  

}

