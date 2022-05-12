using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NightCheck : MonoBehaviour
{
    GameManagerSO managerSO;
    [SerializeField] private UnityEvent dayActivate;
    [SerializeField] private UnityEvent nightActivate;
    public bool nightCheck;
    private bool nightToggle = true;

    private void Awake()
    {
        managerSO = Resources.Load<GameManagerSO>("ScriptableObjects/GameManagerSO");
    }

    private void Update()
    {
        if (nightToggle && managerSO.night)
        {
            nightToggle = false;
            nightCheck = !nightCheck;
            nightActivate.Invoke();
        }
        else if(!nightToggle && !managerSO.night)
        {
            nightToggle = true;
            nightCheck = !nightCheck;
            dayActivate.Invoke();
        }
    }

    public void IsItNight()
    {
        nightCheck = !nightCheck;
        if (nightCheck)
        {
            nightActivate.Invoke();
        }
        else
        {
            dayActivate.Invoke();
        }
    }
}
