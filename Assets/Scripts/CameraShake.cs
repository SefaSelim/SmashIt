using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private HitControl HitArea;

    public void Shake()
    {
        animator.speed = HitArea.maxOpacity / HitArea.currentOpacity / 255 / PlayerStats.CameraShakeDuration ; 
        animator.Play("Shake_Camera", -1, 0f);
    }   
}
