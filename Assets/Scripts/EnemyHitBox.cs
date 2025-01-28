using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public float MaxTakenDamageFromPlayer = 100f;
    public float enemytakendamage;
    float enemyHitCooldown = 0.25f;
    float timer;
    public float enemygivendamage = 10;
    public EnemyHealth _EnemyHealth;
    public PlayerHealth _PlayerHealth;

    [SerializeField] private HitControl HitArea;

     void Start()
    {   
          _EnemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("HitArea"))
            {
                 enemytakendamage = HitArea.playerAttackMultiplier * MaxTakenDamageFromPlayer * 255 * HitArea.currentOpacity / HitArea.maxOpacity;
                _EnemyHealth.TakeDamageEnemy(enemytakendamage);
                Debug.Log("Hit Enemy " + enemytakendamage + " Damage");

            }
           
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
         timer += Time.deltaTime;
         if(collision.gameObject.CompareTag("Player") && timer > enemyHitCooldown )
            {
                _PlayerHealth.TakeDamage(enemygivendamage);
                timer = 0;
            }
    }

}
