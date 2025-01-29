using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBarHandler : MonoBehaviour
{
    [SerializeField] private Image chargeBar;

    private void Update()
    {
        chargeBar.fillAmount = PlayerStats.ChargeAmount;
    }
}
