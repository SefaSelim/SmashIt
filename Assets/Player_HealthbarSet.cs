using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HealthbarSet : MonoBehaviour
{
    [SerializeField] private Image Healthbar;

    private void Update()
    {
        Healthbar.fillAmount = PlayerStats.PlayerHealth / PlayerStats.PlayerMaxHealth;
    }
}
