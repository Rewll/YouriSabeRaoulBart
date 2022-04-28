using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationIntScript : MonoBehaviour
{
    [SerializeField] string floatName;
    private Animator animator;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void ChangeIntValue(float newValue)
    {
        animator.SetFloat(floatName, newValue);
    }

    public void ChangefloatName(string newFloatName)
    {
        floatName = newFloatName;
    }

}
