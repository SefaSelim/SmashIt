using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;
    [SerializeField] private Transform CoinSpawnPoint;

    public void SpawnCoin(int amount)
    {
        GameObject item = Instantiate(Coin, CoinSpawnPoint.position, Quaternion.identity);
        CoinTake coinTake = item.GetComponent<CoinTake>();

        coinTake.CoinEarning = amount;


    }
}
