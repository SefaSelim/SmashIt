using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;

    [TextArea(0, 10)]
    public string Description;
    
    public Sprite itemSprite;

    //STATS FOR PLAYER
    //buranin devamini yapmam icin konusmamiz lazim, neler eklicez falan diye asagidakileri ornek yazdim

    [Header("On Screen")]

    public float ChargeSpeed;
    public float AttackDamage;
    public float CriticalChance;
    public float CriticalDamage;
    public float AttackRange;
    public float Lifesteal;
    public float Regenaration;
    public float DodgeChance;
    public float DashCooldown;
    public float DashAmount;
    public float DoubleGoldChance;
    public float Knockback;
    public float Armor;
    public float Speed;
    public float Health;

    [Space(10)]
    public int Price;
    public int ItemAmount;

    [Header("Hide Stats")]
    public bool isSpecial;
    public int specialAbilityId;
    public string RarityColor;
    public int ItemID;



    private void OnEnable()
    {
        ItemAmount = 0;
    }

}
