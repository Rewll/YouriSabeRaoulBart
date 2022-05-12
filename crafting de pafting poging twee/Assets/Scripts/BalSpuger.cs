using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalSpuger : MonoBehaviour
{
    [SerializeField] private GameObject SpuugBal;
    [SerializeField] private Vector3 shootVelo;
    [SerializeField] private float startSpeed;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = startSpeed;
    }

    public void SpawnWorp() 
    {
        if (GetComponent<SpriteRenderer>().flipX)
        {
            var temp = Instantiate(SpuugBal, new Vector3(0.132f, 0) + transform.position, Quaternion.Euler(0, 0, 0));
            temp.GetComponent<SpuugBal>().Shoot(-shootVelo);
            temp.transform.localScale = transform.localScale;
        }
        else
        {
            var temp = Instantiate(SpuugBal, new Vector3(-0.132f, 0) + transform.position, Quaternion.Euler(0, 0, 0));
            temp.GetComponent<SpuugBal>().Shoot(shootVelo);
            temp.transform.localScale = transform.localScale;
        }
    }

}
