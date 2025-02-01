using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTake : MonoBehaviour
{
    public int CoinEarning;
    bool isearned = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isearned)
        {
            PlayerStats.CoinAmount += CoinEarning;
            isearned = true;
            Debug.Log("Earned");
            Destroy(gameObject);
        }
    }
}
