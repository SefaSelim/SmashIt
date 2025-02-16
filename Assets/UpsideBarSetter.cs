using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpsideBarSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Health;
    [SerializeField] private TextMeshProUGUI RangedAttack;
    [SerializeField] private TextMeshProUGUI Attack;
    [SerializeField] private TextMeshProUGUI Coin;
    [SerializeField] private TextMeshProUGUI Gem;

    private void Update()
    {
        Health.text = PlayerStats.PlayerHealth.ToString();
        RangedAttack.text = PlayerStats.RangeAttackDamage.ToString();
        Attack.text = PlayerStats.AttackDamage.ToString();
        Coin.text = PlayerStats.CoinAmount.ToString();
        Gem.text = PlayerStats.GemAmount.ToString();
    }



}
