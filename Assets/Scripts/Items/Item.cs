using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string Description;
    
    public Sprite itemSprite;

    //STATS FOR PLAYER
    //buranin devamini yapmam icin konusmamiz lazim, neler eklicez falan diye asagidakileri ornek yazdim

    public float AttackSpeedIncreaser;
    public float AttackRangeIncreaser;
    public float AttackDamageIncreaser;
    public float HealthIncreaser;
    public float SpeedIncreaser;
    public float KnockbackIncreaser;
    public float DashIncreaser;
    public float CoinIncreaser;


}
