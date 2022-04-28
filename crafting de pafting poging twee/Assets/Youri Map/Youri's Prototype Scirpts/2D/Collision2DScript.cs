using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class Collision2DScript : MonoBehaviour
{
    [Header("The events")]
    [SerializeField] private UnityEvent collision2DEvent;
    [SerializeField] private UnityEvent collision2DEnterEvent;
    [SerializeField] private UnityEvent collision2DExitEvent;

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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (compareTag && isActive)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (collision.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagCollision2DEvent.Invoke();
                }
            }

        }
        else if (isActive)
        {
            collision2DEvent.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (compareTag && isActive)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (collision.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagCollision2DEnterEvent.Invoke();
                }
            }

        }
        else if (isActive)
        {
            collision2DEnterEvent.Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (compareTag && isActive)
        {
            for (int i = 0; i < tags.Count; i++)
            {
                if (collision.gameObject.CompareTag(tags[i].tag))
                {
                    tags[i].tagCollision2DExitEvent.Invoke();
                }
            }

        }
        else if (isActive)
        {
            collision2DExitEvent.Invoke();
        }
    }

    [System.Serializable]
    public class Tag
    {
        public string tag;
        public UnityEvent tagCollision2DEvent;
        public UnityEvent tagCollision2DEnterEvent;
        public UnityEvent tagCollision2DExitEvent;
    }
}
