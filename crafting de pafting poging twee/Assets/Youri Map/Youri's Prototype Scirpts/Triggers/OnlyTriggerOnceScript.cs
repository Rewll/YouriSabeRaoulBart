using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class OnlyTriggerOnceScript : MonoBehaviour
{
    [SerializeField] private List<OncesTriggers> theTriggers;
    private Dictionary<string, int> triggerNames;

    private void Start()
    {
        for (int i = 0; i < theTriggers.Count; i++)
        {
            triggerNames.Add(theTriggers[i].name, i);
        }
       
    }

    public void ActivateTrigger(string triggerName)
    {
        if (triggerNames.ContainsKey(triggerName))
        {
            if (!theTriggers[triggerNames[triggerName]].IsActivatedBefore)
            {
                theTriggers[triggerNames[triggerName]].triggerOnce.Invoke();
                theTriggers[triggerNames[triggerName]].IsActivatedBefore = true;
            }
        }
        else
        {
            Debug.LogWarning(triggerName + " is Not found");
        }
    }

    public void ResetTrigger(string triggerName)
    {
        if (triggerNames.ContainsKey(triggerName))
        {
                theTriggers[triggerNames[triggerName]].IsActivatedBefore = false;
        }
        else
        {
            Debug.LogWarning(triggerName + " is Not found");
        }
    }


    [System.Serializable]
    public class OncesTriggers
    {
        [Header("setting")]
        public string name;
        public bool IsActivatedBefore;

        [Header("Event")]
        public UnityEvent triggerOnce;
    }


}
