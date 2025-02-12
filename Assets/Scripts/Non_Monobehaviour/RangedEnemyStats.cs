using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RangedEnemyStats
{
     public static float rangedEnemyHealth = 150; 
    public static float rangedEnemyMaxHealth = 150;
    //RANGEDENEMYMOVE.CS
    public static float rangedEnemySpeed = 3;

    public static float rangedEnemyCooldown = 1f;

    //ENEMYHITBOX.CS
    public static float enemyGivenDamage = 10; //melee için de dokunulduğunda aynı hasar vereceği için ortak
    
}
