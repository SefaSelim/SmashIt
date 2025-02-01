
using System.Collections.Generic;
using UnityEngine;

public class CoinMoveToPlayer : MonoBehaviour
{
    public float CoinSpeed = 2.5f;

    Vector2 PlayerPosition;
    Vector2 direction;

    [SerializeField] Transform CoinPosition;
    bool collisionDone = false;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPosition = collision.transform.position;
            collisionDone = true;
        }


    }


    private void Update()
    {
        if (collisionDone)
        {
            MoveToPlayer();
        }
    }


    private void  MoveToPlayer()
    {
        CoinPosition.position = Vector2.Lerp(CoinPosition.position , PlayerPosition,Time.deltaTime * CoinSpeed);
    }

}
