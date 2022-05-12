using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightEffect : AbstractMainEffect
{
    GameManagerSO managerSO;
    GameObject hitObject;

    private void Awake()
    {
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
    }

    public override void DrinkEffect()
    {
        //Player and all other objects live in the night.
        //Pro: Other object's night cycles can be an advantage to the player.
        //Con: Player can't see much. Other object's night cycles can be a disadvantage to the player.
        
        managerSO.night = !managerSO.night;
    }

    public override void ThrowEffect()
    {
        //Other object lives in the night. 
        //Pro: Player can trigger night-effect of a single other object to player's advantage. Other objects aren't affected.
        //Con: You can't have the night-time advantages of multiple objects at once.
        hitObject = gameObject.GetComponent<PotionClass>().geraakteGameObject;
        var temp = hitObject.GetComponent<NightCheck>();
        if (temp != null) 
        { 
            temp.IsItNight();
        }
        
    }
}
