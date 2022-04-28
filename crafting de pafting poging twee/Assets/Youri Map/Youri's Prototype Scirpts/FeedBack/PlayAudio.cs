using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public class PlayAudio : MonoBehaviour
{
    [SerializeField] private List<AudioData> audioManager;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        for (int i = 0; i < audioManager.Count; i++)
        {
            if (audioManager[i].activateOnStart)
            {
                audioSource?.PlayOneShot(audioManager[i].audioClip);
            }
        }
    }

    public void PlayClipByNumber(int audioNumber)
    {
        audioSource.PlayOneShot(audioManager[audioNumber].audioClip);
    }

    public void PlayClipByName(string audioName)
    {
        for (int i = 0; i < audioManager.Count; i++)
        {
            if (audioName == audioManager[i].nameAudio)
            {
                audioSource.PlayOneShot(audioManager[i].audioClip);
            }
        }
    }

    [System.Serializable]
    public class AudioData
    {
        [Header("Name audio")]
        public string nameAudio;

        [Header("Audio clip")]
        public AudioClip audioClip;

        [Header("Activate on start")]
        public bool activateOnStart;
    }

}
