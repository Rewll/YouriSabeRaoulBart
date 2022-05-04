using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IngredientenName", menuName = ("ScriptableObjects/PotionIngredient"))]
public class PotionIngredient : ScriptableObject
{
    public Sprite potionSprite;
    public Color potionColor;
    public List<string> potionGroup;
    public List<Effect> effects;
    
}
[System.Serializable]
public class Effect 
{
    public SideEffects allEffects;
    public float addAmount;
}

public enum SideEffects
{
    speed,
    arm,
}