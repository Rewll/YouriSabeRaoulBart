using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScriptAbleDataScript : MonoBehaviour
{
    public ScriptAbleDataScript data;

    public void SetBool(string dataName,bool boolState)
    {
        for (int i = 0; i < data.bools.Count; i++)
        {
            if (data.bools[i].boolName == dataName)
            {
                data.bools[i].active = boolState;
            }
        }
    }

    public void GetInt(string dataName ,float floatNumber)
    {
        for (int i = 0; i < data.floats.Count; i++)
        {
            if (data.floats[i].floatName == dataName)
            {
                data.floats[i].storedNumber = floatNumber;
            }
        }
    }

}
