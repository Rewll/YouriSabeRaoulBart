using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DataObject",menuName ="ScriptableObjects/DataObject")]
public class ScriptAbleDataScript : ScriptableObject
{
    public List<BoolList> bools;
    public List<FloatsList> floats;
    public List<VectorList> vectors;
}

[System.Serializable]
public class BoolList
{
    [Header("Bool")]
    public string boolName;
    public bool active;
}

[System.Serializable]
public class FloatsList
{
    [Header("Floats")]
    public string floatName;
    public float storedNumber;
}

[System.Serializable]
public class VectorList
{
    [Header("Vectors")]
    public string vectorName;
    public Vector3 storedVector;
}