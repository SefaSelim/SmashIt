using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyHitBox : MonoBehaviour
{
    public float enemyArmor = 1f;
    public float enemytakendamage;
    float enemyHitCooldown = 1f;

    float timer;
    float knockbackDebugTimer;
    public EnemyHealth _EnemyHealth;
    public PlayerHealth _PlayerHealth;
     public string enemyStatsName;

    public EnemyStats enemyStats;

    [SerializeField] private Rigidbody2D EnemyRB;
    [SerializeField] private GameObject Player;
    [SerializeField] private float knockbackForce;

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
          _EnemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        knockbackDebugTimer += Time.deltaTime;

        if (EnemyRB.velocity != Vector2.zero)
        {
            if (knockbackDebugTimer >= PlayerStats.KnockbackDuration)
            {
                EnemyRB.velocity = Vector2.zero;
            }
        }
        else
        {
            knockbackDebugTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("HitArea"))
            {
                 enemytakendamage = PlayerStats.AttackDamage * enemyArmor * PlayerStats.ChargeAmount;
                _EnemyHealth.TakeDamageEnemy(enemytakendamage);
                Debug.Log("Hit Enemy " + enemytakendamage + " Damage");

                Knockback(transform.position - Player.transform.position);
                Invoke("KnockbackReset", PlayerStats.KnockbackDuration);

        }
           
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
         if(collision.gameObject.CompareTag("Player") && timer > enemyHitCooldown && !PlayerStats.IsDashing)
            {
                _PlayerHealth.TakeDamage(enemyStats.damage);
                timer = 0;
            }
    }

    private void Knockback(Vector2 direction)
    {
        EnemyRB.AddForce(PlayerStats.ChargeAmount * direction.normalized * PlayerStats.KnokbackForce, ForceMode2D.Impulse);
    }
    
    private void KnockbackReset()
    {
        EnemyRB.velocity = Vector2.zero;
    }

}
