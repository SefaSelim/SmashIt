using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetCoinAmount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CoinAmount;

    private void Update()
    {
        CoinAmount.text = PlayerStats.CoinAmount.ToString();
    }
}
