using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    //ENEMYHITBOX.CS
    public static float KnockbackDuration = 0.15f;      // �tmenin ne kadar s�re uygulanaca��
    public static bool IsDashing = false;               // is player dashing

    //PLAYERMOVEMENT.CS
    public static float PlayerMovementSpeed = 4f; //Kullanıcı hareket hızı
    public static Vector3 PlayerScale = new Vector3(1.25f,1.25f,1); //Kullanıcı büyüklüğü (movementın startta ayarlanıyor)

    //PLAYERHEALTH.CS
    public static float PlayerHealth = 100f;            // Kullan�c�n�n can�
    public static float PlayerMaxHealth = 100f;         // Kullan�c�n�n maksimum can�

    //CAMERASHAKE.CS
    public static float CameraShakeDuration = 1f;          // Kamera sallanma h�z�

    //HITCONTROL.CS
    public static float AttackDamage = 100f;              // Kullan�c�n�n sald�r� hasar�
    public static float RangeAttackDamage = 100f;

    //COINSPAWNER.CS
    public static int CoinAmount = 200;                     
    public static int GemAmount = 0;


    //STORE STATS

    public static float ChargeSpeed;
    public static float CriticalChance;
    public static float CriticalDamage;
    public static float AttackRangeRatio = 100f;       //baglanamadi amina kodumun seysi
    public static float Lifesteal;
    public static float Regenaration;
    public static float DodgeChance;
    public static float DashCooldown;
    public static float DashAmount;
    public static float DoubleGoldChance;
    public static float KnokbackForce = 10f;    //baglandi
    public static float Armor;
    public static float Speed;



    //DYNAMIC VARIABLES ( USE READONLY )
    public static float ChargeAmount;                      // Players attack charge amount  ( 0f to 1f )

}
