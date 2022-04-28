using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private bool fireCode;

    [Header("PotionSettings")]
    [SerializeField] private GameObject gPotion;
    private List<Color> IngredientColors = new List<Color>();
    private List<Effect> brewEffects = new List<Effect>();
    private List<string> brewGroup = new List<string>();

    private void Update()
    {
        if (fireCode)
        {
            fireCode = false;
            BrewPotion();
        }
    }

    public void BrewPotion()
    {
        if(IngredientColors.Count > 0) 
        {
            GameObject newPotion = Instantiate(gPotion);
            newPotion.GetComponent<SpriteRenderer>().color = BrewColor();
            AddFunctionToBrew(newPotion);
            AddMainEffect(newPotion);
        }
        ResetBrewLists();
    }

    public void AddIngredient(PotionIngredient addedIngredient) 
    {
        Debug.Log(addedIngredient.potionColor);
        IngredientColors.Add(addedIngredient.potionColor);
        AddEffectsToBrewList(addedIngredient.effects);
        AddGroupToBrewList(addedIngredient.potionGroup);
    }

    private Color BrewColor()
    {
        var TempColor = new Color(0, 0, 0);
        foreach (var color in IngredientColors)
        {
            TempColor += color;
        }

        TempColor = TempColor / IngredientColors.Count;

        return TempColor;
    }
    private void AddFunctionToBrew(GameObject newPotion) 
    {
        //Debug.Log("Seks?");
        foreach (var newEffect in brewEffects)
        {
            //VeelSuc6 Raoul
            if(newEffect.allEffects == SideEffects.speed) 
            {
                var temp = newPotion.GetComponent<SpeedEffect>();
                if (temp) 
                {
                   temp.EffectCount(newEffect.addAmount);
                }
                else 
                {
                   temp = newPotion.AddComponent<SpeedEffect>();
                   temp.EffectCount(newEffect.addAmount);
                }
            }
            if (newEffect.allEffects == SideEffects.arm)
            {
                var temp = newPotion.GetComponent<ArmEffect>();
                if (temp)
                {
                    temp.EffectCount(newEffect.addAmount);
                }
                else
                {
                    temp = newPotion.AddComponent<ArmEffect>();
                    temp.EffectCount(newEffect.addAmount);
                }
            }
        }
    }
    private void AddEffectsToBrewList(List<Effect> ingredientEffect)
    {
        foreach (var newEffect in ingredientEffect)
        {
            brewEffects.Add(newEffect);
        }   
    }

    private void AddGroupToBrewList(List<string> newGroup) 
    { 
        foreach (var newGroupItem in newGroup)
        {
            brewGroup.Add(newGroupItem);
        }
    }

    private void AddMainEffect(GameObject newPotion) 
    {
        //Main Effects
        if (brewGroup.Contains("Animal") && brewGroup.Contains("Fruit")) 
        {
            newPotion.AddComponent<FireEffect>();
            return;
        }
    }

    private void ResetBrewLists() 
    {
        brewEffects = new List<Effect>();
        IngredientColors = new List<Color>();
    }
}
