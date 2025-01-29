using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyStats : MonoBehaviour
{
    //ENEMYHEALTH.CS
    public static float meleeEnemyHealth = 100; 
    //MELEEENEMYMOVE.CS
    public static float meleeEnemySpeed = 3;

    //ENEMYHITBOX.CS
    public static float enemyGivenDamage = 10; //ranged için de dokunulduğunda aynı hasar vereceği için ortak
}
