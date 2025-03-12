using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        PlayerStats.PlayerHealth -= amount;
        Debug.Log("player health is : "  + PlayerStats.PlayerHealth);
        if(PlayerStats.PlayerHealth <= 0)
        {
            PlayerDie();
        }
    }
    private void PlayerDie()
    {
        gameObject.SetActive(false); // Animasyon eklenecek
        Time.timeScale = 0;
    }
}
