using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MeleeEnemyMove : MonoBehaviour
{
    public Dictionary<PlayerState, int> IndexPair = new();
     public SPUM_Prefabs _prefabs;
     public GameObject unitRoot;
    public PlayerMovement playerMovement;
    Vector3 target_position;
    Vector3 enemy_position;
    
    public EnemyStats enemyStats;
    public string enemyStatsName;


    void Awake()
{   
    if (GameManager.Instance == null)
    {
        Debug.LogError("GameManager.Instance bulunamadı! Sahnedeki GameManager aktif mi?");
        return;
    }

    if (GameManager.Instance.enemyStatsDatabase == null)
    {
        Debug.LogError("GameManager.Instance.enemyStatsDatabase atanmadı!");
        return;
    }

    Debug.Log("GameManager ve enemyStatsDatabase bulundu.");
    
    enemyStats = GameManager.Instance.enemyStatsDatabase.GetStatsByName(enemyStatsName);

    if (enemyStats == null)
    {
        Debug.LogError("enemyStats bulunamadı! enemyStatsName: " + enemyStatsName);
    }
    else
    {
        Debug.Log("enemyStats bulundu: " + enemyStats.enemyName);
    }
}

    void Start()
    
    {
       
        if(unitRoot == null)
        {
            unitRoot = this.transform.GetChild(0).gameObject;
        }
         if (_prefabs == null)
        {
            _prefabs = GetComponent<SPUM_Prefabs>();
            if (!_prefabs.allListsHaveItemsExist())
            {
                _prefabs.PopulateAnimationLists();
            }
        }
       

        _prefabs.OverrideControllerInit();

        foreach (PlayerState state in Enum.GetValues(typeof(PlayerState)))
        {
            IndexPair[state] = 0;
        }
        
    

        if (playerMovement == null)
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }
    }

    void Update()
    {
     
        _prefabs.PlayAnimation(PlayerState.MOVE, IndexPair[PlayerState.MOVE]);
        target_position = playerMovement.transform.position; 
        enemy_position = transform.position; 
       
        MoveMeleeEnemy();
    }

    Vector3 FindShortestPath()
    {
        return (target_position - enemy_position).normalized;
    }

    void MoveMeleeEnemy()
    {
        Vector3 direction = FindShortestPath();
        transform.position += direction * enemyStats.speed * Time.deltaTime; 
        if(transform.position.x < playerMovement.transform.position.x)
        unitRoot.transform.localScale = new Vector3(-1,1,1);
        else if (transform.position.x > playerMovement.transform.position.x)
        unitRoot.transform.localScale = new Vector3(1,1,1);

    }
}
