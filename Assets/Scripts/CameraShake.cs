using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private HitControl HitArea;

    void Start()
    {
        animator.enabled = false;
    }

    public void Shake()
    {
        animator.enabled = true;
        animator.speed = HitArea.maxOpacity / HitArea.currentOpacity / 255 / PlayerStats.CameraShakeDuration ; 
        animator.Play("Shake_Camera", -1, 0f);
      

    }   
}
