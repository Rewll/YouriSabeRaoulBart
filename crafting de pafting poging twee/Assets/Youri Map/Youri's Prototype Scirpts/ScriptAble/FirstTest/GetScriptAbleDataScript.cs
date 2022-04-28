using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetScriptAbleDataScript : MonoBehaviour
{

    public ScriptAbleDataScript data;
    [SerializeField] private UnityEvent<bool> boolInfo;
    [SerializeField] private UnityEvent<bool,string> boolInfoWithName;
    [SerializeField] private UnityEvent<float> floatInfo;
    [SerializeField] private UnityEvent<float,string> floatInfoWithName;

    public void GetBool(string dataName)
    {
        for (int i = 0; i < data.bools.Count; i++)
        {
            if(data.bools[i].boolName == dataName)
            {
                boolInfo.Invoke(data.bools[i].active);
            }
        }
    }

    public void GetInt(string dataName)
    {
        for (int i = 0; i < data.floats.Count; i++)
        {
            if (data.floats[i].floatName == dataName)
            {
                floatInfo.Invoke(data.floats[i].storedNumber);
            }
        }
    }

    public void GetBoolWithName(string dataName)
    {
        for (int i = 0; i < data.bools.Count; i++)
        {
            if (data.bools[i].boolName == dataName)
            {
                boolInfoWithName.Invoke(data.bools[i].active,dataName);
            }
        }
    }

    public void GetIntWtihName(string dataName)
    {
        for (int i = 0; i < data.floats.Count; i++)
        {
            if (data.floats[i].floatName == dataName)
            {
                floatInfoWithName.Invoke(data.floats[i].storedNumber,dataName);
            }
        }
    }
}
