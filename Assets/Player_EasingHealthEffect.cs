using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player_EasingHealthEffect : MonoBehaviour
{
    public float player_lerpspeed = 0.008f;

    [SerializeField] private Image EaseBar;
    float currentHealth;

    private void Start()
    {
        currentHealth = PlayerStats.PlayerHealth;
    }
    void Update()
    {
        if (currentHealth != PlayerStats.PlayerHealth)
        {
            currentHealth = Mathf.Lerp(currentHealth, PlayerStats.PlayerHealth, player_lerpspeed);
            EaseBar.fillAmount = currentHealth / PlayerStats.PlayerMaxHealth;
        }

    }
}
