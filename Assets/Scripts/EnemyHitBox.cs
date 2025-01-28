using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public float MaxTakenDamageFromPlayer = 100f;

    [SerializeField] private HitControl HitArea;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("HitArea"))
            {
                Debug.Log("Hit Enemy " + HitArea.playerAttackMultiplier * MaxTakenDamageFromPlayer * 255 * HitArea.currentOpacity / HitArea.maxOpacity + " Damage");
            }
    }
}
