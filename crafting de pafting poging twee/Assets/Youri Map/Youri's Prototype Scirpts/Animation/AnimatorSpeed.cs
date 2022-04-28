using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeed : MonoBehaviour
{
    private Animator Animator;
    private void Awake()
    {
        Animator = gameObject.GetComponent<Animator>();
    }

    public void AnimationSpeedChange(float Speed)
    {
        Animator.speed = Speed;
    }

    public void AnimationSpeedReset()
    {
        Animator.speed = 1;
    }

    public void AnimationSpeedZero()
    {
        Animator.speed = 0;
    }
}
