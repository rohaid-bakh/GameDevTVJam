using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource myAudioSource;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayClip(AudioClip clip)
    {
        if (myAudioSource != null && clip != null)
        {
            myAudioSource.clip = clip;
            myAudioSource.Play();
        }
    }
}
