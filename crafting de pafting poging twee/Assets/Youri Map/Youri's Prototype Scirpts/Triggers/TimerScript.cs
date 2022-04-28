using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class TimerScript : MonoBehaviour
{
    [SerializeField] private List<TimerData> timerManager;

    void Start()
    {
        for (int i = 0; i < timerManager.Count; i++)
        {
            if (timerManager[i].activateOnStart)
            {
                StartCoroutine(Timer(i));
            }
        }
    }

    public void StartTimerByNumber(int timerNumber)
    {
        StartCoroutine(Timer(timerNumber));
    }

    public void StartTimerByName(string timerName)
    {
        for (int i = 0; i < timerManager.Count; i++)
        {
            if (timerName == timerManager[i].nameTimer)
            {
                StartCoroutine(Timer(i));
            }
        }

    }



    IEnumerator Timer(int timerNumber)
    {
        yield return new WaitForSeconds(timerManager[timerNumber].timerLengt);
        timerManager[timerNumber].OnTimerDone.Invoke();
    }

    [System.Serializable]
    public class TimerData
    {
        [Header("Name timer")]
        public string nameTimer;

        [Header("Settings")]
        public bool activateOnStart;
        public float timerLengt;

        [Header("Event")]
        public UnityEvent OnTimerDone;
    }
}
