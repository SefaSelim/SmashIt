using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemExplainer : MonoBehaviour
{
    public TextMeshProUGUI ItemExplanation;

    public TextMeshProUGUI CriticalChance;
    public TextMeshProUGUI CriticalDamage;
    public TextMeshProUGUI AttackRange;
    public TextMeshProUGUI Lifesteal;
    public TextMeshProUGUI Regenaration;
    public TextMeshProUGUI DodgeChance;
    public TextMeshProUGUI DashCooldown;
    public TextMeshProUGUI DashAmount;
    public TextMeshProUGUI DoubleGoldChance;
    public TextMeshProUGUI Knockback;
    public TextMeshProUGUI Armor;
    public TextMeshProUGUI Speed;


    private void Awake()
    {
        StaticItemExplainer.ExistingItems.Clear();
    }
    private void Update()
    {
        ItemExplanation.text = StaticItemExplainer.Explanation;


        CriticalChance.text = StaticItemExplainer.CriticalChance.ToString();
        CriticalDamage.text = StaticItemExplainer.CriticalDamage.ToString();
        AttackRange.text = StaticItemExplainer.AttackRange.ToString();
        Lifesteal.text = StaticItemExplainer.Lifesteal.ToString();
        Regenaration.text = StaticItemExplainer.Regenaration.ToString();
        DodgeChance.text = StaticItemExplainer.DodgeChance.ToString();
        DashCooldown.text = StaticItemExplainer.DashCooldown.ToString();
        DashAmount.text = StaticItemExplainer.DashAmount.ToString();
        DoubleGoldChance.text = StaticItemExplainer.DoubleGoldChance.ToString();
        Knockback.text = StaticItemExplainer.Knockback.ToString();
        Armor.text = StaticItemExplainer.Armor.ToString();
        Speed.text = StaticItemExplainer.Speed.ToString();
    }

}
