using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;

    [SerializeField] private Image healthBar;
    void Start()
    {
        if (gameObject.GetComponent<MeleeEnemyMove>() != null) //Düşman melee ise ranged ise rangedstats eklenmeli
        {
            enemyHealth = MeleeEnemyStats.meleeEnemyHealth;
        }
    }





    public void TakeDamageEnemy(float amount)
    {
        enemyHealth -= amount;
        healthBar.fillAmount = 1 - (enemyHealth / 100);
        Debug.Log("enemy health is: " + enemyHealth);
        if (enemyHealth <= 0)
        {
            EnemyDie();
        }
    }
    private void EnemyDie()
    {

        Destroy(gameObject);

    }
}
