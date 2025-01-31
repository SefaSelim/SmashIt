using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTake : MonoBehaviour
{
    public int CoinEarning;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats.CoinAmount += CoinEarning;

            Destroy(gameObject);
        }
    }
}
