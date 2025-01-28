using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyMove : MonoBehaviour
{

    public PlayerMovement playerMovement;
    Vector3 target_position;
    Vector3 enemy_position;

    public float meleeEnemySpeed = 2.5f;

    void Start()
    {
        if (playerMovement == null)
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }
    }

    void Update()
    {
     

        target_position = playerMovement.transform.position; 
        enemy_position = transform.position; 
       
        MoveMeleeEnemy();
    }

    Vector3 FindShortestPath()
    {
        return (target_position - enemy_position).normalized;
    }

    void MoveMeleeEnemy()
    {
        Vector3 direction = FindShortestPath();
        transform.position += direction * meleeEnemySpeed * Time.deltaTime; 
    }
}
