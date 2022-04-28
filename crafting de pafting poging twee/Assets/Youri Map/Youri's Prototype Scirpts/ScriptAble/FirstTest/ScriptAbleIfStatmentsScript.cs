using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScriptAbleIfStatmentsScript : MonoBehaviour
{
    public ScriptAbleDataScript data;
    [SerializeField] private List<IfStatmentsBool> ifBools;
    [SerializeField] private List<IfStatmentsFloat> ifFloats;

    private Dictionary<string, int> boolDictionary = new Dictionary<string, int>();
    private Dictionary<string, int> boolIfStatementsDictionary = new Dictionary<string, int>();

    private Dictionary<string, int> floatDictionary = new Dictionary<string, int>();
    private Dictionary<string, int> floatIfStatementsDictionary = new Dictionary<string, int>();

    private void Start()
    {
        for (int i = 0; i < data.bools.Count; i++)
        {
            boolDictionary.Add(data.bools[i].boolName, i);
        }

        for (int i = 0; i < data.floats.Count; i++)
        {
            floatDictionary.Add(data.floats[i].floatName, i);
        }

        for (int i = 0; i < ifBools.Count; i++)
        {
            boolIfStatementsDictionary.Add(ifBools[i].nameIfStatment, i);
        }

        for (int i = 0; i < ifFloats.Count; i++)
        {
            floatIfStatementsDictionary.Add(ifFloats[i].nameIfStatment, i);
        }
    }

    private void Update()
    {
        //bool ---------------------------------------------------------------------------------------------------------------------------------------------------------
        for (int i = 0; i < ifBools.Count; i++)
        {
            if (ifBools[i].updating)
            {
                if (boolDictionary.ContainsKey(ifBools[i].nameOfBool))
                {
                    if (!ifBools[i].compare)
                    {
                        if (data.bools[boolDictionary[ifBools[i].nameOfBool]].active == ifBools[i].IfTrue)
                        {
                            ifBools[i].isTrue.Invoke();
                        }
                        else
                        {
                            ifBools[i].isFalse.Invoke();
                        }
                    }
                    else
                    {
                        if (boolDictionary.ContainsKey(ifBools[i].nameOfComparingBool))
                        {
                            if (data.bools[boolDictionary[ifBools[i].nameOfBool]].active == data.bools[boolDictionary[ifBools[i].nameOfComparingBool]].active)
                            {
                                ifBools[i].isTrue.Invoke();
                            }
                            else
                            {
                                ifBools[i].isFalse.Invoke();
                            }
                        }
                        else
                        {
                            Debug.LogWarning(ifBools[i].nameOfComparingBool + " is not found.");
                        }

                    }
                }
                else
                {
                    Debug.LogWarning(ifBools[i].nameOfBool + " is not found.");
                }
            }
        }

        //int -------------------------------------------------------------------------------------------------------------------------------
        for (int i = 0; i < ifFloats.Count; i++)
        {
            if (ifFloats[i].updating)
            {
                if (floatDictionary.ContainsKey(ifFloats[i].nameOfFloat))
                {
                    if (ifFloats[i].checkIfSmaller)
                    {
                        //smaller
                        if (!ifFloats[i].compare)
                        {
                            if (data.floats[floatDictionary[ifFloats[i].nameOfFloat]].storedNumber < ifFloats[i].compareWithValue)
                            {
                                ifFloats[i].doMatch.Invoke();
                            }
                            else
                            {
                                ifFloats[i].dontMatch.Invoke();
                            }
                        }
                        else
                        {
                            if (floatDictionary.ContainsKey(ifFloats[i].nameOfComparingFloat))
                            {
                                if (data.floats[floatDictionary[ifFloats[i].nameOfFloat]].storedNumber < data.floats[floatDictionary[ifFloats[i].nameOfComparingFloat]].storedNumber)
                                {
                                    ifFloats[i].doMatch.Invoke();
                                }
                                else
                                {
                                    ifFloats[i].dontMatch.Invoke();
                                }
                            }
                            else
                            {
                                Debug.LogWarning(ifFloats[i].nameOfComparingFloat + " is not found.");
                            }
                        }
                    }
                    else if (ifFloats[i].checkIfBigger)
                    {
                        //bigger
                        if (!ifFloats[i].compare)
                        {
                            if (data.floats[floatDictionary[ifFloats[i].nameOfFloat]].storedNumber > ifFloats[i].compareWithValue)
                            {
                                ifFloats[i].doMatch.Invoke();
                            }
                            else
                            {
                                ifBools[i].isFalse.Invoke();
                            }
                        }
                        else
                        {
                            if (floatDictionary.ContainsKey(ifFloats[i].nameOfComparingFloat))
                            {
                                if (data.floats[floatDictionary[ifFloats[i].nameOfFloat]].storedNumber > data.floats[floatDictionary[ifFloats[i].nameOfComparingFloat]].storedNumber)
                                {
                                    ifFloats[i].doMatch.Invoke();
                                }
                                else
                                {
                                    ifFloats[i].dontMatch.Invoke();
                                }
                            }
                            else
                            {
                                Debug.LogWarning(ifFloats[i].nameOfComparingFloat + " is not found.");
                            }
                        }
                    }
                    else
                    {
                        //equals
                        if (!ifFloats[i].compare)
                        {
                            if (data.floats[floatDictionary[ifFloats[i].nameOfFloat]].storedNumber == ifFloats[i].compareWithValue)
                            {
                                ifFloats[i].doMatch.Invoke();
                            }
                            else
                            {
                                ifFloats[i].dontMatch.Invoke();
                            }
                        }
                        else
                        {
                            if (floatDictionary.ContainsKey(ifFloats[i].nameOfComparingFloat))
                            {
                                if (data.floats[floatDictionary[ifFloats[i].nameOfFloat]].storedNumber == data.floats[floatDictionary[ifFloats[i].nameOfComparingFloat]].storedNumber)
                                {
                                    ifFloats[i].doMatch.Invoke();
                                }
                                else
                                {
                                    ifFloats[i].dontMatch.Invoke();
                                }
                            }
                            else
                            {
                                Debug.LogWarning(ifFloats[i].nameOfComparingFloat + " is not found.");
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogWarning(ifFloats[i].nameOfFloat + " is not found.");
                }
            }
        }
    }

    public void CheckIfBool(string StateName)
    {
        if (boolIfStatementsDictionary.ContainsKey(StateName))
        {
            if(boolDictionary.ContainsKey(ifBools[boolIfStatementsDictionary[StateName]].nameOfBool))
            {
                if (!ifBools[boolIfStatementsDictionary[StateName]].compare)
                {
                    if (data.bools[boolDictionary[ifBools[boolIfStatementsDictionary[StateName]].nameOfBool]].active == ifBools[boolIfStatementsDictionary[StateName]].IfTrue)
                    {
                        ifBools[boolIfStatementsDictionary[StateName]].isTrue.Invoke();
                    }
                    else
                    {
                        ifBools[boolIfStatementsDictionary[StateName]].isFalse.Invoke();
                    }
                }
                else
                {
                    if (boolDictionary.ContainsKey(ifBools[boolIfStatementsDictionary[StateName]].nameOfComparingBool))
                    {
                        if (data.bools[boolDictionary[ifBools[boolIfStatementsDictionary[StateName]].nameOfBool]].active == data.bools[boolDictionary[ifBools[boolIfStatementsDictionary[StateName]].nameOfComparingBool]].active)
                        {
                            ifBools[boolIfStatementsDictionary[StateName]].isTrue.Invoke();
                        }
                        else
                        {
                            ifBools[boolIfStatementsDictionary[StateName]].isFalse.Invoke();
                        }
                    }
                    else
                    {
                        Debug.LogWarning(ifBools[boolIfStatementsDictionary[StateName]].nameOfComparingBool + " is not found.");
                    }

                }
            }
            else
            {
                Debug.LogWarning(ifBools[boolIfStatementsDictionary[StateName]].nameOfBool + " is not found.");
            }
        }
        else
        {
            Debug.LogWarning(StateName + " is not found.");
        }
    }


    public void CheckIfInt(string StateName)
    {
        if (floatDictionary.ContainsKey(StateName))
        {
            if (floatDictionary.ContainsKey(ifFloats[floatIfStatementsDictionary[StateName]].nameOfFloat))
            {
                if (ifFloats[floatIfStatementsDictionary[StateName]].checkIfSmaller)
                {
                    //smaller
                    if (!ifFloats[floatIfStatementsDictionary[StateName]].compare)
                    {
                        if (data.floats[floatDictionary[ifFloats[floatIfStatementsDictionary[StateName]].nameOfFloat]].storedNumber < ifFloats[floatIfStatementsDictionary[StateName]].compareWithValue)
                        {
                            ifFloats[floatIfStatementsDictionary[StateName]].doMatch.Invoke();
                        }
                        else
                        {
                            ifFloats[floatIfStatementsDictionary[StateName]].dontMatch.Invoke();
                        }
                    }
                    else
                    {
                        if (floatDictionary.ContainsKey(ifFloats[floatIfStatementsDictionary[StateName]].nameOfComparingFloat))
                        {
                            if (data.floats[floatDictionary[ifFloats[floatIfStatementsDictionary[StateName]].nameOfFloat]].storedNumber < data.floats[floatDictionary[ifFloats[floatIfStatementsDictionary[StateName]].nameOfComparingFloat]].storedNumber)
                            {
                                ifFloats[floatIfStatementsDictionary[StateName]].doMatch.Invoke();
                            }
                            else
                            {
                                ifFloats[floatIfStatementsDictionary[StateName]].dontMatch.Invoke();
                            }
                        }
                        else
                        {
                            Debug.LogWarning(ifFloats[boolIfStatementsDictionary[StateName]].nameOfComparingFloat + " is not found.");
                        }
                    }
                }
                else if (ifFloats[floatIfStatementsDictionary[StateName]].checkIfBigger)
                {
                    //bigger
                    if (!ifFloats[floatIfStatementsDictionary[StateName]].compare)
                    {
                        if (data.floats[floatDictionary[ifFloats[floatIfStatementsDictionary[StateName]].nameOfFloat]].storedNumber > ifFloats[floatIfStatementsDictionary[StateName]].compareWithValue)
                        {
                            ifFloats[floatIfStatementsDictionary[StateName]].dontMatch.Invoke();
                        }
                        else
                        {
                            ifFloats[floatIfStatementsDictionary[StateName]].dontMatch.Invoke();
                        }
                    }
                    else
                    {
                        if (floatDictionary.ContainsKey(ifFloats[floatIfStatementsDictionary[StateName]].nameOfComparingFloat))
                        {
                            if (data.floats[floatDictionary[ifFloats[floatIfStatementsDictionary[StateName]].nameOfFloat]].storedNumber > data.floats[floatDictionary[ifFloats[floatIfStatementsDictionary[StateName]].nameOfComparingFloat]].storedNumber)
                            {
                                ifFloats[floatIfStatementsDictionary[StateName]].doMatch.Invoke();
                            }
                            else
                            {
                                ifFloats[floatIfStatementsDictionary[StateName]].dontMatch.Invoke();
                            }
                        }
                        else
                        {
                            Debug.LogWarning(ifFloats[boolIfStatementsDictionary[StateName]].nameOfComparingFloat + " is not found.");
                        }
                    }
                }
                else
                {
                    //equals
                    if (!ifFloats[floatIfStatementsDictionary[StateName]].compare)
                    {
                        if (data.floats[floatDictionary[ifFloats[floatIfStatementsDictionary[StateName]].nameOfFloat]].storedNumber == ifFloats[floatIfStatementsDictionary[StateName]].compareWithValue)
                        {
                            ifFloats[floatIfStatementsDictionary[StateName]].doMatch.Invoke();
                        }
                        else
                        {
                            ifFloats[floatIfStatementsDictionary[StateName]].dontMatch.Invoke();
                        }
                    }
                    else
                    {
                        if (floatDictionary.ContainsKey(ifFloats[floatIfStatementsDictionary[StateName]].nameOfComparingFloat))
                        {
                            if (data.floats[floatDictionary[ifFloats[floatIfStatementsDictionary[StateName]].nameOfFloat]].storedNumber == data.floats[floatDictionary[ifFloats[floatIfStatementsDictionary[StateName]].nameOfComparingFloat]].storedNumber)
                            {
                                ifFloats[floatIfStatementsDictionary[StateName]].doMatch.Invoke();
                            }
                            else
                            {
                                ifFloats[floatIfStatementsDictionary[StateName]].dontMatch.Invoke();
                            }
                        }
                        else
                        {
                            Debug.LogWarning(ifFloats[boolIfStatementsDictionary[StateName]].nameOfComparingFloat + " is not found.");
                        }
                    }
                }
            }
            else
            {
                Debug.LogWarning(ifFloats[boolIfStatementsDictionary[StateName]].nameOfFloat + " is not found.");
            }
        }
        else
        {
            Debug.LogWarning(StateName + " is not found.");
        }
    }


    [System.Serializable]
    public class IfStatmentsBool
    {
        [Header("setting")]
        public string nameIfStatment;
        public bool compare;
        public bool updating;
        public bool IfTrue = true;
        
        [Header("Bool Name")]
        public string nameOfBool;
        public string nameOfComparingBool;

        [Header("Events")]
        public UnityEvent isTrue;
        public UnityEvent isFalse;
    }

    [System.Serializable]
    public class IfStatmentsFloat
    {
        [Header("setting")]
        public string nameIfStatment;
        public bool compare;
        public bool updating;

        [Space]
        public float compareWithValue;
        public bool checkIfSmaller;
        public bool checkIfBigger;

        [Header("Bool Name")]
        public string nameOfFloat;
        public string nameOfComparingFloat;

        [Header("Events")]
        public UnityEvent doMatch;
        public UnityEvent dontMatch;


    }
}
