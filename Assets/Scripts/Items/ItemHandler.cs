using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandler : MonoBehaviour
{

    ItemHandler(Item ExternalItem)
    {
        Item = ExternalItem;
    }

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
            Debug.Log("Item Added");
            image = GetComponent<Image>();
            button = GetComponent<Button>();

            image.sprite = Item.itemSprite;
            button.onClick.AddListener(ShowItemExplanation);

            AddNew();
        }

    }

    public void AddNew()
    {
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

        Item.ItemAmount++;
        StaticItemExplainer.ExistingItems.Add(Item);
    }

    public void AddExisting()
    {
        Item existItem = StaticItemExplainer.ExistingItems.Find(x => x == Item);

        existItem.ItemAmount++;

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


        Destroy(gameObject);
    }

    private void Update()
    {
        ItemAmount.text = Item.ItemAmount.ToString();
    }


}