using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeleeEnemyStats
{
    //ENEMYHEALTH.CS
    public static float meleeEnemyHealth = 200; 
    public static float meleeEnemyMaxHealth = 200;
    //MELEEENEMYMOVE.CS
    public static float meleeEnemySpeed = 3;

    //ENEMYHITBOX.CS
    public static float enemyGivenDamage = 10; //ranged için de dokunulduğunda aynı hasar vereceği için ortak
}
