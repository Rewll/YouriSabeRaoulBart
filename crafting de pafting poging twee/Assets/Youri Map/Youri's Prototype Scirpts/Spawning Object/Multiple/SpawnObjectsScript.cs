using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectsScript : MonoBehaviour
{

    [SerializeField] private List<SpawnableObjects> objectList;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            if (objectList[i].spawnOnStart)
            {
                if (objectList[i].useTransformInsteadOfVectors)
                {
                    Instantiate(objectList[i].spawnableObject, objectList[i].spawntransform);
                }
                else
                {
                    Instantiate(objectList[i].spawnableObject, objectList[i].spawnlocation, Quaternion.Euler(objectList[i].spawnRotation));
                }
            }
        }
    }

    public void SpawnObjectOnLocation(int objectNumber,Vector3 posistion,Vector3 rotation)
    {
        Instantiate(objectList[objectNumber].spawnableObject, posistion, Quaternion.Euler(rotation));
    }

    public void SpawnObjectOnTransform(int objectNumber,Transform transform)
    {
        Instantiate(objectList[objectNumber].spawnableObject,transform);
    }

}



[System.Serializable]
public class SpawnableObjects
{
    [Header("Object")]
    public string objectName;
    public GameObject spawnableObject;

    [Header("Spawnlocation")]
    public Vector3 spawnlocation;   
    public Vector3 spawnRotation;
    [Space]
    [Space]
    [Space]
    public Transform spawntransform;

    [Header("Settings")]
    public bool spawnOnStart;
    public bool useTransformInsteadOfVectors;


}

