using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public float MaxTakenDamageFromPlayer = 100f;
    public float damage;
    public EnemyHealth _EnemyHealth;

    [SerializeField] private HitControl HitArea;

     void Start()
    {   
          _EnemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("HitArea"))
            {
                 damage = HitArea.playerAttackMultiplier * MaxTakenDamageFromPlayer * 255 * HitArea.currentOpacity / HitArea.maxOpacity;
                _EnemyHealth.TakeDamageEnemy(damage);
                Debug.Log("Hit Enemy " + damage + " Damage");

            }
    }
}
