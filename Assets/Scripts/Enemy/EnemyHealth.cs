using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    void Start()
    {
        if(gameObject.GetComponent<MeleeEnemyMove>()!=null) //Düşman melee ise
        {
            enemyHealth = MeleeEnemyStats.meleeEnemyHealth;
        }
            //Ranged ise RangedEnemyStats...
    }






    public void TakeDamageEnemy(float amount)
    {
        enemyHealth -= amount;
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
