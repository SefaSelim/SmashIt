using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSystem : MonoBehaviour
{
    public Transform playertransform;
    public List<WaveData> waveDatas = new List<WaveData>();
    public List<GameObject> enemyTypes = new List<GameObject>();
    GameObject meleeEnemy;
    GameObject rangedEnemy;
    public int currentWave = 0;
    float timerforspawnenemy = 0;
    float timerforwave = 0;
    public TextMeshProUGUI timertext;
    bool iswaveclear = false;

    void Start()
    {
        meleeEnemy = enemyTypes.Find(e => e.name == "MeleeEnemy");
        rangedEnemy = enemyTypes.Find(e => e.name == "RangedEnemy");

        Debug.Log($"Melee Enemy: {meleeEnemy}, Ranged Enemy: {rangedEnemy}");

        if (meleeEnemy == null || rangedEnemy == null)
        {
            Debug.LogError("Enemy prefab not found! Check names in enemyTypes list.");
        }

        CreateWave();
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
        for (int i = 0; i < waveDatas[currentWave].meleeEnemyCount; i++)
        {
            Vector3 spawnPosition = GetSpawnPosition();
            Instantiate(meleeEnemy, spawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < waveDatas[currentWave].rangedEnemyCount; i++)
        {
            Vector3 spawnPosition = GetSpawnPosition();
            Instantiate(rangedEnemy, spawnPosition, Quaternion.identity);
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

    void UpdateTimerText()
    {
        
        if(iswaveclear)
        {
        timertext.text = "WAVE CLEAR";}
        else
        {
        int minutes = Mathf.FloorToInt(timerforwave / 60);
        int seconds = Mathf.FloorToInt(timerforwave % 60);
        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);}

    }
}

[System.Serializable]
public class WaveData
{
    public int meleeEnemyCount;
    public int rangedEnemyCount;

    public float enemySpawnCooldown;
    public float timeforwinningwave;
}
