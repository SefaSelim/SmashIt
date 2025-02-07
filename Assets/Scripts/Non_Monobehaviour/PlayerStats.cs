using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    //ENEMYHITBOX.CS
    public static float KnokbackForce = 10f;            // �tme kuvveti
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
    public static float PlayerAttackMultiplier = 1f;       // Kullan�c�n�n sald�r� g�c�

    //COINSPAWNER.CS
    public static int CoinAmount = 0;                      // Kullan�c�n�n toplad��� alt�n say�s�   




    //DYNAMIC VARIABLES ( USE READONLY )
    public static float ChargeAmount;                      // Players attack charge amount  ( 0f to 1f )

}
