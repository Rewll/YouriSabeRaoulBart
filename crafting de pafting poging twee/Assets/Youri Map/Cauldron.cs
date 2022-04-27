using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
   
    //Temp testing
    [SerializeField] private PotionIngredient potionIngredient;
    [SerializeField] private PotionIngredient potionIngredient2;
    [SerializeField] private bool fireCode;

    [Header("PotionSettings")]
    [SerializeField] private GameObject gPotion;
    [SerializeField] private List<Color> IngredientColors;
    [SerializeField] private List<Effect> brewEffects;
    [SerializeField] private List<AbstactSideEffect> sideEffects;

    private void Start()
    {
        AddIngredient(potionIngredient);
        AddIngredient(potionIngredient2);
    }

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
        GameObject newPotion = Instantiate(gPotion);
        newPotion.GetComponent<SpriteRenderer>().color = BrewColor();
        AddFunctionToBrew(newPotion);
    }

    public void AddIngredient(PotionIngredient addedIngredient) 
    {
        IngredientColors.Add(addedIngredient.potionColor);
        AddEffectsToBrewList(addedIngredient.effects);
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
            if(newEffect.allEffects == AllEffects.speed) 
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
            if (newEffect.allEffects == AllEffects.arm)
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


}
