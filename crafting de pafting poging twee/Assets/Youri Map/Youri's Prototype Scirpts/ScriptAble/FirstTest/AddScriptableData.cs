using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AddScriptableData : MonoBehaviour
{
    public ScriptAbleDataScript data;
    [SerializeField] private List<AdderInfo> adderList;
    Dictionary<string, int> adderDictionary = new Dictionary<string, int>();
    Dictionary<string, int> floatDictionary = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < data.floats.Count; i++)
        {
            floatDictionary.Add(data.floats[i].floatName, i);
        }

        for (int i = 0; i < adderList.Count; i++)
        {
            adderDictionary.Add(adderList[i].nameAdder, i);
        }
    }

    public void AddFloat(string adderName)
    {
        if (adderDictionary.ContainsKey(adderName))
        {
            if (floatDictionary.ContainsKey(adderList[adderDictionary[adderName]].NameFloat))
            {

                if (!adderList[adderDictionary[adderName]].AddWithSecondFloat)
                {
                    if (adderList[adderDictionary[adderName]].minus)
                    {
                        float newValue = data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameFloat]].storedNumber - adderList[adderDictionary[adderName]].addedValue;
                        adderList[adderDictionary[adderName]].NewFloat.Invoke(newValue);
                        adderList[adderDictionary[adderName]].NewFloatWithName.Invoke(newValue, adderList[adderDictionary[adderName]].NameFloat);
                    }
                    else if (adderList[adderDictionary[adderName]].times)
                    {
                        float newValue = data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameFloat]].storedNumber * adderList[adderDictionary[adderName]].addedValue;
                        adderList[adderDictionary[adderName]].NewFloat.Invoke(newValue);
                        adderList[adderDictionary[adderName]].NewFloatWithName.Invoke(newValue, adderList[adderDictionary[adderName]].NameFloat);
                    }
                    else if (adderList[adderDictionary[adderName]].divided)
                    {
                        float newValue = data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameFloat]].storedNumber / adderList[adderDictionary[adderName]].addedValue;
                        adderList[adderDictionary[adderName]].NewFloat.Invoke(newValue);
                        adderList[adderDictionary[adderName]].NewFloatWithName.Invoke(newValue, adderList[adderDictionary[adderName]].NameFloat);
                    }
                    else
                    {
                        float newValue = data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameFloat]].storedNumber + adderList[adderDictionary[adderName]].addedValue;
                        adderList[adderDictionary[adderName]].NewFloat.Invoke(newValue);
                        adderList[adderDictionary[adderName]].NewFloatWithName.Invoke(newValue, adderList[adderDictionary[adderName]].NameFloat);
                    }
                }
                else
                {
                    if (floatDictionary.ContainsKey(adderList[adderDictionary[adderName]].NameSecondFloat))
                    {
                        if (adderList[adderDictionary[adderName]].minus)
                        {
                            float newValue = data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameFloat]].storedNumber - data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameSecondFloat]].storedNumber;
                            adderList[adderDictionary[adderName]].NewFloat.Invoke(newValue);
                            adderList[adderDictionary[adderName]].NewFloatWithName.Invoke(newValue, adderList[adderDictionary[adderName]].NameFloat);
                        }
                        else if (adderList[adderDictionary[adderName]].times)
                        {
                            float newValue = data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameFloat]].storedNumber * data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameSecondFloat]].storedNumber;
                            adderList[adderDictionary[adderName]].NewFloat.Invoke(newValue);
                            adderList[adderDictionary[adderName]].NewFloatWithName.Invoke(newValue, adderList[adderDictionary[adderName]].NameFloat);
                        }
                        else if (adderList[adderDictionary[adderName]].divided)
                        {
                            float newValue = data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameFloat]].storedNumber / data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameSecondFloat]].storedNumber;
                            adderList[adderDictionary[adderName]].NewFloat.Invoke(newValue);
                            adderList[adderDictionary[adderName]].NewFloatWithName.Invoke(newValue, adderList[adderDictionary[adderName]].NameFloat);
                        }
                        else
                        {
                            float newValue = data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameFloat]].storedNumber + data.floats[floatDictionary[adderList[adderDictionary[adderName]].NameSecondFloat]].storedNumber;
                            adderList[adderDictionary[adderName]].NewFloat.Invoke(newValue);
                            adderList[adderDictionary[adderName]].NewFloatWithName.Invoke(newValue, adderList[adderDictionary[adderName]].NameFloat);
                        }
                    }
                    else
                    {
                        Debug.LogWarning(adderList[adderDictionary[adderName]].NameSecondFloat + " is not found in ScriptableObject");

                    }
                }
            }
            else
            {
                Debug.LogWarning(adderList[adderDictionary[adderName]].NameFloat + " is not found in ScriptableObject");
            }
        }
        else
        {
           Debug.LogWarning(adderName + " is not found in Adderlist"); 
        }
    }

    [System.Serializable] 
    public class AdderInfo
    {
        [Header("Adder")]
        public string nameAdder;
        public string NameFloat;
        public float addedValue;

        [Header("Add second float")]
        public bool AddWithSecondFloat;
        public string NameSecondFloat;

        [Header("Diffrent adding method")]
        public bool minus;
        public bool times;
        public bool divided;

        [Header("The Event")]
        public UnityEvent<float> NewFloat;
        public UnityEvent<float,string> NewFloatWithName;
    }
}
