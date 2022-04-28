using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPostionScript : MonoBehaviour
{

    [SerializeField] private List<Postions> postionList;
    [Space]
    [Header("Settings")]
    [SerializeField] private int decimalNumbers = 1;


    void Update()
    {
        for (int i = 0; i < postionList.Count; i++)
        {
            if(gameObject.transform.position.Round(decimalNumbers) == postionList[i].position)
            {
                postionList[i].onPosition.Invoke();
            }
        }
    }
}

[System.Serializable]
public class Postions
{
    [Header("Position Name")]
    public string posName;

    [Header("Position")]
    public Vector3 position;

    [Header("The Event")]
    public UnityEvent onPosition;

}

static class ExtensionMethods
{
    public static Vector3 Round(this Vector3 vector3,int decimalPlaces = 2)
{
    float multiplier = 1;
    for (int i = 0; i < decimalPlaces; i++)
    {
        multiplier *= 10f;
    }
    return new Vector3(
        Mathf.Round(vector3.x * multiplier) / multiplier,
        Mathf.Round(vector3.y * multiplier) / multiplier,
        Mathf.Round(vector3.z * multiplier) / multiplier);
}
}

