using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100;
    public SPUM_Prefabs _prefabs;
    private PlayerState _currentState;
    public Dictionary<PlayerState, int> IndexPair = new();
    void Start()
    {
          if (_prefabs == null)
        {
            _prefabs = transform.GetChild(0).GetComponent<SPUM_Prefabs>();
            if (!_prefabs.allListsHaveItemsExist())
            {
                _prefabs.PopulateAnimationLists();
            }
        }

        _prefabs.OverrideControllerInit();

        foreach (PlayerState state in Enum.GetValues(typeof(PlayerState)))
        {
            IndexPair[state] = 0;
        }
    }

    public void PlayStateAnimation(PlayerState state)
    {
        _prefabs.PlayAnimation(state, IndexPair[state]);
    }

    void Update()
    {
        PlayStateAnimation(_currentState);
    }

    public void TakeDamageEnemy(float amount)
    {
        enemyHealth -= amount;
        Debug.Log("enemy health is: " + enemyHealth);
        if (enemyHealth <= 0)
        {
            EnemyDie();
        }
    }
    private void EnemyDie()
    {

         Destroy(gameObject);

    }
}
