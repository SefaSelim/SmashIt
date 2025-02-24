    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    public class EnemyHealth : MonoBehaviour
    {
        [HideInInspector] public float enemyHealth;
        [HideInInspector] public float maxEnemyHealth;
        public EnemyStats enemyStats;
        public string enemyStatsName;

        [SerializeField] private CoinSpawner coinSpawner;
        public int CoinEarningFromEnemy;

        [SerializeField] private Image healthBar;


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
           
                enemyHealth = enemyStats.health;
                maxEnemyHealth = enemyStats.health;
            
        }





        public void TakeDamageEnemy(float amount)
        {
            enemyHealth -= amount;
            healthBar.fillAmount = enemyHealth / maxEnemyHealth;

            Debug.Log("enemy health is: " + enemyHealth);
            if (enemyHealth <= 0)
            {
                EnemyDie();
                coinSpawner.SpawnCoin(CoinEarningFromEnemy);
            }
        }
        private void EnemyDie()
        {

            Destroy(gameObject);

        }
    }
