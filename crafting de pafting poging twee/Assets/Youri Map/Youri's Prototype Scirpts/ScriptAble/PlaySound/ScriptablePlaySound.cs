using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New PlaySound", menuName = "ScriptableObjects/PlaySound")]
public class ScriptablePlaySound : ScriptableObject
{
    [SerializeField] private List<AudioData> audioManager;
    [HideInInspector] public UnityEvent<AudioClip> PlaySound;

    public void PlayClipByNumber(int audioNumber)
    {
        if (audioNumber < audioManager.Count && audioNumber >= 0)
        {
            PlaySound.Invoke(audioManager[audioNumber].audioClip);
        }
        else 
        {
            Debug.LogWarning(audioNumber.ToString() + " is out of the list range of " + this.name);
        }
    }

    public void PlayClipByName(string audioName)
    {
        for (int i = 0; i < audioManager.Count; i++)
        {
            if (audioName == audioManager[i].nameAudio)
            {
                PlaySound.Invoke(audioManager[i].audioClip);
            }
            else
            {
                Debug.LogWarning(audioName + " is not a name in the list of " + this.name);
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
    }
}
