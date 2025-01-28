using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    float playerHealth = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        playerHealth -= amount;
        Debug.Log("player health is : "  + playerHealth);
        if(playerHealth <= 0)
        {
            PlayerDie();
        }
    }
    private void PlayerDie()
    {
        gameObject.SetActive(false); // Animasyon eklenecek
    }
}
