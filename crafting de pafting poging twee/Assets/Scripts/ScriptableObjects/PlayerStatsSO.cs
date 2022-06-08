using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = ("ScriptableObjects/PlayerStats"))]
public class PlayerStatsSO : ScriptableObject
{
    public Color playerColor;
    public int throwButton = 0;
    public int drinkButton = 1;
}