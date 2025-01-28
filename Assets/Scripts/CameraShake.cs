using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Shake()
    {
        animator.Play("Shake_Camera", -1, 0f);
    }   
}
