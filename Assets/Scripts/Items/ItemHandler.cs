using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{


    public Item Item;

    [SerializeField] private TextMeshProUGUI ItemAmount;


    Image image;
    Button button;

    public void ShowItemExplanation()
    {
             StaticItemExplainer.Explanation = Item.Description;
    }

    private void Start()
    {
        if (StaticItemExplainer.ExistingItems.Contains(Item))
        {
            AddExisting();
        }
        else
        {
            image = GetComponent<Image>();
            button = GetComponent<Button>();

            image.sprite = Item.itemSprite;
            button.onClick.AddListener(ShowItemExplanation);

            AddNew();
        }

    }

    public void AddNew()
    {
        StaticItemExplainer.ChargeSpeed += Item.ChargeSpeed;
        StaticItemExplainer.CriticalChance += Item.CriticalChance;
        StaticItemExplainer.CriticalDamage += Item.CriticalDamage;
        StaticItemExplainer.AttackRange += Item.AttackRange;
        StaticItemExplainer.Lifesteal += Item.Lifesteal;
        StaticItemExplainer.Regenaration += Item.Regenaration;
        StaticItemExplainer.DodgeChance += Item.DodgeChance;
        StaticItemExplainer.DashCooldown += Item.DashCooldown;
        StaticItemExplainer.DashAmount += Item.DashAmount;
        StaticItemExplainer.DoubleGoldChance += Item.DoubleGoldChance;
        StaticItemExplainer.Knockback += Item.Knockback;
        StaticItemExplainer.Armor += Item.Armor;
        StaticItemExplainer.Speed += Item.Speed;

        PlayerStats.AttackDamage += Item.AttackDamage;
        PlayerStats.PlayerHealth += Item.Health;


        Item.ItemAmount++;
        StaticItemExplainer.ExistingItems.Add(Item);
    }

    public void AddExisting()
    {
        Item existItem = StaticItemExplainer.ExistingItems.Find(x => x == Item);

        existItem.ItemAmount++;

        StaticItemExplainer.ChargeSpeed += Item.ChargeSpeed;
        StaticItemExplainer.CriticalChance += Item.CriticalChance;
        StaticItemExplainer.CriticalDamage += Item.CriticalDamage;
        StaticItemExplainer.AttackRange += Item.AttackRange;
        StaticItemExplainer.Lifesteal += Item.Lifesteal;
        StaticItemExplainer.Regenaration += Item.Regenaration;
        StaticItemExplainer.DodgeChance += Item.DodgeChance;
        StaticItemExplainer.DashCooldown += Item.DashCooldown;
        StaticItemExplainer.DashAmount += Item.DashAmount;
        StaticItemExplainer.DoubleGoldChance += Item.DoubleGoldChance;
        StaticItemExplainer.Knockback += Item.Knockback;
        StaticItemExplainer.Armor += Item.Armor;
        StaticItemExplainer.Speed += Item.Speed;

        PlayerStats.ChargeSpeed += Item.ChargeSpeed;
        PlayerStats.CriticalChance += Item.CriticalChance;
        PlayerStats.CriticalDamage += Item.CriticalDamage;
        PlayerStats.AttackRangeRatio += Item.AttackRange;
        PlayerStats.Lifesteal += Item.Lifesteal;
        PlayerStats.Regenaration += Item.Regenaration;
        PlayerStats.DodgeChance += Item.DodgeChance;
        PlayerStats.DashCooldown += Item.DashCooldown;
        PlayerStats.DashAmount += Item.DashAmount;
        PlayerStats.DoubleGoldChance += Item.DoubleGoldChance;
        PlayerStats.KnokbackForce += Item.Knockback;
        PlayerStats.Armor += Item.Armor;
        PlayerStats.Speed += Item.Speed;

        PlayerStats.AttackDamage += Item.AttackDamage;
        PlayerStats.PlayerHealth += Item.Health;


        Destroy(gameObject);
    }

    private void Update()
    {
        ItemAmount.text = Item.ItemAmount.ToString();
    }


}