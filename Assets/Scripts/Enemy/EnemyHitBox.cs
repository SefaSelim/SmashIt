using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public float MaxTakenDamageFromPlayer = 100f;
    public float enemytakendamage;
    float enemyHitCooldown = 1f;

    float timer;
    float knockbackDebugTimer;
    public EnemyHealth _EnemyHealth;
    public PlayerHealth _PlayerHealth;

    [SerializeField] private Rigidbody2D EnemyRB;
    [SerializeField] private GameObject Player;
    [SerializeField] private float knockbackForce;

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
                 enemytakendamage = PlayerStats.PlayerAttackMultiplier * MaxTakenDamageFromPlayer * PlayerStats.ChargeAmount;
                _EnemyHealth.TakeDamageEnemy(enemytakendamage);
                Debug.Log("Hit Enemy " + enemytakendamage + " Damage");

                Knockback(transform.position - Player.transform.position);
                Invoke("KnockbackReset", PlayerStats.KnockbackDuration);

        }
           
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
         if(collision.gameObject.CompareTag("Player") && timer > enemyHitCooldown )
            {
                _PlayerHealth.TakeDamage(MeleeEnemyStats.enemyGivenDamage);
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
