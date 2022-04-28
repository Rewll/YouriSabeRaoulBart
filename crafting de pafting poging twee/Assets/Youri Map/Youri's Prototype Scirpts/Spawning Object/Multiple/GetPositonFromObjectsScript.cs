using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[DisallowMultipleComponent]
public class GetPositonFromObjectsScript : MonoBehaviour
{

    [SerializeField] private List<SendLocations> sendTo;
    private Transform objectTransform;
    private Vector3 objectPosition;
    private Vector3 objectRotation;


    public void GetPosViaTransWithNumb(int x)
    {
        if (sendTo[x].useName)
        {
            sendTo[x].sendTransformViaName.Invoke(sendTo[x].locationName, objectTransform);
        }
        else
        {
            sendTo[x].sendTransform.Invoke(sendTo[x].locationNumber,objectTransform);
        }
    }
    public void GetPosViaTransWithName(string inputName)
    {
        for (int i = 0; i < sendTo.Count; i++)
        {

            if(sendTo[i].locationName == inputName)
            {
                if (sendTo[i].useName)
                {
                    sendTo[i].sendTransformViaName.Invoke(sendTo[i].locationName, objectTransform);
                }
                else
                {
                    sendTo[i].sendTransform.Invoke(sendTo[i].locationNumber,objectTransform);
                }   
            }
        }
    }

    public void GetPosViaVectWithNumb(int x)
    {
        if (sendTo[x].useName)
        {
            sendTo[x].sendVector3ViaName.Invoke(sendTo[x].locationName, objectPosition, objectRotation);
        }
        else
        {
            sendTo[x].sendVector3.Invoke(sendTo[x].locationNumber,objectPosition, objectRotation);
        }  
    }

    public void GetPosViaVectWithName(string inputName)
    {
        for (int i = 0; i < sendTo.Count; i++)
        {
            if (sendTo[i].locationName == inputName)
            {
                if (sendTo[i].useName)
                {
                    sendTo[i].sendVector3ViaName.Invoke(sendTo[i].locationName, objectPosition, objectRotation);
                }
                else
                {
                    sendTo[i].sendVector3.Invoke(sendTo[i].locationNumber,objectPosition, objectRotation);
                }
                
            }
        }
    }

    private void Update()
    {
        objectTransform = gameObject.transform;
        objectPosition = gameObject.transform.position;
        objectRotation = gameObject.transform.rotation.eulerAngles;
    }

}

[System.Serializable]
public class SendLocations
{
    [Header("Location")]
    [SerializeField]
    public string locationName;
    public int locationNumber;
    public bool useName;

    [Header("Events With Int")]
    public UnityEvent<int,Transform> sendTransform;
    public UnityEvent<int,Vector3,Vector3> sendVector3;

    [Header("Events With Name")]
    public UnityEvent<string, Transform> sendTransformViaName;
    public UnityEvent<string,Vector3,Vector3> sendVector3ViaName;


}
