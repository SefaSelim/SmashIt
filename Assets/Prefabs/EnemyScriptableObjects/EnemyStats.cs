using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "New Enemy" , menuName = "Enemy")]
public class EnemyStats : ScriptableObject
{
    public string enemyName;
    public float maxHealth;
    public float speed;
    public float damage;

    public float bulletspeed;
    public float bulletcooldown;
    
    public float health;
}
