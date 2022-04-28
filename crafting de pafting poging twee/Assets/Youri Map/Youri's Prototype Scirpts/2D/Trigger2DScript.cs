using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class Trigger2DScript : MonoBehaviour
{
    [Header("The event")]
    [SerializeField] private UnityEvent Trigger2DEvent;
    [SerializeField] private UnityEvent Trigger2DEnterEvent;
    [SerializeField] private UnityEvent Trigger2DExitEvent;

    [Header("Settings")]
    [SerializeField] private bool isActive = true;
    [Space]
    [SerializeField] private bool compareTag;
    [SerializeField] private List<Tag> tags;

    public void IsActive(bool active)
    {
        isActive = active;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (compareTag)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (other.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagTrigger2DEvent.Invoke();
                }
            }

        }
        if (isActive)
        {
            Trigger2DEvent.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (compareTag)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (other.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagTrigger2DEnterEvent.Invoke();
                }
            }

        }
        if (isActive)
        {
            Trigger2DEnterEvent.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (compareTag)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (other.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagTrigger2DExitEvent.Invoke();
                }
            }

        }
        if (isActive)
        {
            Trigger2DExitEvent.Invoke();
        }
    }

    [System.Serializable]
    public class Tag
    {
        public string tag;
        public UnityEvent tagTrigger2DEvent;
        public UnityEvent tagTrigger2DEnterEvent;
        public UnityEvent tagTrigger2DExitEvent;
    }
}
