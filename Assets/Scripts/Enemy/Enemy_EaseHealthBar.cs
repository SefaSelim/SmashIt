using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_EaseHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyHealth _EnemyHealth;
    [SerializeField] private Image EaseBar;

    [SerializeField] private float lerpSpeed = 0.008f;

    float currentHealth;
    void Start()
    {
        currentHealth = _EnemyHealth.enemyHealth;
        EaseBar.fillAmount = currentHealth / _EnemyHealth.maxEnemyHealth;
    }

    void Update()
    {
        if (currentHealth != _EnemyHealth.enemyHealth)
        {
            currentHealth = Mathf.Lerp(currentHealth, _EnemyHealth.enemyHealth, lerpSpeed);
            EaseBar.fillAmount = currentHealth / _EnemyHealth.maxEnemyHealth;
        }
    }
}
