using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public RangedEnemyMove rangedEnemyMove; 
    public float bulletspeed = 15f;
    public float bulletdamage = 10f;
     GameObject playerMovement;
     Vector3 target_position;
     Vector3 enemy_position;// Start is called before the first frame update
    float timerForDestroy = 0;
    public Vector3 direction;
    public string enemyStatsName = "RangedEnemy";
    public EnemyStats enemyStats;


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

        bulletdamage =enemyStats.damage;
        bulletspeed =enemyStats.bulletspeed;
        
        playerMovement = GameObject.Find("PlayerCharacter");
        playerHealth = playerMovement.GetComponent<PlayerHealth>();
         target_position = playerMovement.transform.position; 
         enemy_position = transform.position; 
        direction = FindShortestPath();
    }

     Vector3 FindShortestPath()
    {
        return (target_position - enemy_position).normalized;
    }
    void Update()
    {
        BulletMove();
        timerForDestroy += Time.deltaTime;
        if(timerForDestroy > 10)
        {
            Destroy(gameObject);
        }
        
    }
    void BulletMove()
    {   
        target_position = playerMovement.transform.position; 
        enemy_position = transform.position; 
        
        transform.position += direction * bulletspeed * Time.deltaTime; 
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !PlayerStats.IsDashing)
        {
          playerHealth.TakeDamage(bulletdamage);
        }
    }
}
