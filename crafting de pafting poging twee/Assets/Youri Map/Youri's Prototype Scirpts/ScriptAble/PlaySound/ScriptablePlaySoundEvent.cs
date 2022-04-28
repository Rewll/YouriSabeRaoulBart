using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[DisallowMultipleComponent]
public class ScriptablePlaySoundEvent : MonoBehaviour
{
    [SerializeField] private List<ScriptablePlaySound> SOPlaySounds;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < SOPlaySounds.Count; i++)
        {
            if (SOPlaySounds[i] != null)
            {
                SOPlaySounds[i].PlaySound.AddListener(PlayClip);
            }
            else 
            {
                Debug.LogWarning("Element " + i.ToString() + " in the list has no scriptable object assigned on the object " + this.name);
            }
        } 
    }

    private void OnDisable()
    {
        for (int i = 0; i < SOPlaySounds.Count; i++)
        {
            SOPlaySounds[i].PlaySound.RemoveListener(PlayClip);
        }
    }

    private void PlayClip(AudioClip audioClip) 
    {
        audioSource.PlayOneShot(audioClip);
    }

}
