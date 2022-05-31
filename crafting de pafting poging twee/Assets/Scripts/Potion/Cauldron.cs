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
    [SerializeField]
    private Sprite[] couldronSprites;
    private int couldronSpriteNum = 0;

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
        couldronSpriteNum = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = couldronSprites[couldronSpriteNum];
    }

    public void AddIngredient(PotionIngredient addedIngredient) 
    {
        couldronSpriteNum++;
        if (couldronSpriteNum <= couldronSprites.Length)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = couldronSprites[couldronSpriteNum];
        }


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
        if (brewGroup.Contains("Steen") && brewGroup.Contains("Plant")) 
        {
            var temp = newPotion.AddComponent<FireEffect>();
            return;
        } //IK HOU HIERVAN ^
        if(brewGroup.Contains("Water")&& brewGroup.Contains("Air")) 
        {
            var temp = newPotion.AddComponent<AirEffect>();
            return;
        }
        if (brewGroup.Contains("Fire") && brewGroup.Contains("Air"))
        {
            var temp = newPotion.AddComponent<VuurEffect>();
            return;
        }
        if (brewGroup.Contains("Darkness") && brewGroup.Contains("Fire"))
        {
            var temp = newPotion.AddComponent<DayNightEffect>();
            return;
        }
        if (brewGroup.Contains("Darkness") && brewGroup.Contains("Air"))
        {
            var temp = newPotion.AddComponent<CloudEffect>();
            return;
        }
    }

    private void ResetBrewLists() 
    {
        brewEffects = new List<Effect>();
        IngredientColors = new List<Color>();
        brewGroup = new List<string>();
    }
}
