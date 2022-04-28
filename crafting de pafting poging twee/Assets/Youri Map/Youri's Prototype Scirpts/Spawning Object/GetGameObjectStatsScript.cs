using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetGameObjectStatsScript : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> sendGameobject;
    [SerializeField] private UnityEvent<Vector3> sendPosision;
    [SerializeField] private UnityEvent<Vector3> sendRotation;

    public void SendPos()
    {
        sendPosision.Invoke(this.transform.position);
    }
    public void SendRot()
    {
        sendRotation.Invoke(this.transform.rotation.eulerAngles);
    }

    public void SendObj()
    {
        sendGameobject.Invoke(this.gameObject);
    }
}
