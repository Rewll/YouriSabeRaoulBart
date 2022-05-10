using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerSO", menuName = ("ScriptableObjects/GameManagerSO"))]
public class GameManagerSO : ScriptableObject
{
    //Contols
    public KeyCode abilityKeyCode;

    //Abilitys
    public float blowAbilityBlowTime;

    public bool night;

    public GameObject player;
}
