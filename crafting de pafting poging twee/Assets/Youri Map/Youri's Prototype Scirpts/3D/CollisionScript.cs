using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class CollisionScript : MonoBehaviour
{
    [Header("The events")]
    [SerializeField] private UnityEvent collisionEvent;
    [SerializeField] private UnityEvent collisionEnterEvent;
    [SerializeField] private UnityEvent collisionExitEvent;

    [Header("Settings")]
    [SerializeField] private bool isActive = true;
    [Space]
    [SerializeField] private bool compareTag;
    [SerializeField] private List<Tag> tags;
    //[Space]

    public void IsActive(bool active)
    {
        isActive = active;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (compareTag && isActive)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (collision.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagCollisionEvent.Invoke();
                }
            }

        }
        else if (isActive)
        {
            collisionEvent.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (compareTag && isActive)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (collision.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagCollisionEnterEvent.Invoke();
                }
            }

        }
        else if (isActive)
        {
            collisionEnterEvent.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (compareTag && isActive)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (collision.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagCollisionExitEvent.Invoke();
                }
            }

        }
        else if (isActive)
        {
            collisionExitEvent.Invoke();
        }
    }

    [System.Serializable]
    public class Tag
    {
        public string tag;
        public UnityEvent tagCollisionEvent;
        public UnityEvent tagCollisionEnterEvent;
        public UnityEvent tagCollisionExitEvent;
    }
}
