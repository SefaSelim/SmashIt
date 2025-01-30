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

    [SerializeField] private Image healthBar;
    void Start()
    {
        if (gameObject.GetComponent<MeleeEnemyMove>() != null) //Düşman melee ise ranged ise rangedstats eklenmeli
        {
            enemyHealth = MeleeEnemyStats.meleeEnemyHealth;
            maxEnemyHealth = MeleeEnemyStats.meleeEnemyMaxHealth;
        }
    }





    public void TakeDamageEnemy(float amount)
    {
        enemyHealth -= amount;
        healthBar.fillAmount = enemyHealth / maxEnemyHealth;

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
