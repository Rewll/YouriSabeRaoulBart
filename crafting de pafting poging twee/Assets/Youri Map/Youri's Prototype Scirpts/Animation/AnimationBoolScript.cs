using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class AnimationBoolScript : MonoBehaviour
{
    private Animator Animator;
    private void Awake()
    {
        if (this.GetComponent<Animator>() != null)
        {
            Animator = this.GetComponent<Animator>();
        }
        else
        {
            Debug.LogWarning("No Animator Found on" + gameObject.ToString());
        }
       
    }
    public void AnimBoolToggle(string boolName)
    {
        Animator.SetBool(boolName, !Animator.GetBool(boolName));
    }   

    public void AnimBoolTrue(string boolName)
    {
        Animator.SetBool(boolName, true);
    }

    public void AnimBoolFalse(string boolName)
    {
        Animator.SetBool(boolName, false);
    }

}

