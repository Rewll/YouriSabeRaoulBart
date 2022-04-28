using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class TriggerScript : MonoBehaviour
{
    [Header("The event")]
    [SerializeField] private UnityEvent TriggerEvent;
    [SerializeField] private UnityEvent TriggerEnterEvent;
    [SerializeField] private UnityEvent TriggerExitEvent;

    [Header("Settings")]
    [SerializeField] private bool isActive = true;
    [Space]
    [SerializeField] private bool compareTag;
    [SerializeField] private List<Tag> tags;

    public void IsActive(bool active)
    {
        isActive = active;
    }

    private void OnTriggerStay(Collider other)
    {
        if (compareTag && isActive)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (other.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagTriggerEvent.Invoke();
                }
            }

        }
        else if (isActive)
        {
            TriggerEvent.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (compareTag && isActive)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (other.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagTriggerEnterEvent.Invoke();
                }
            }

        }
        else if (isActive)
        {
            TriggerEnterEvent.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (compareTag && isActive)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (other.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagTriggerExitEvent.Invoke();
                }
            }

        }
        else if (isActive)
        {
            TriggerExitEvent.Invoke();
        }
    }

    [System.Serializable]
    public class Tag
    {
        public string tag;
        public UnityEvent tagTriggerEvent;
        public UnityEvent tagTriggerEnterEvent;
        public UnityEvent tagTriggerExitEvent;
    }
}
