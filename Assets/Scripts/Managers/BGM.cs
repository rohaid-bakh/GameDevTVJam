using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField] private AudioClip[] bgmClips;

    private int currentClip = -1;

    public bool canPlayMusic = false;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (bgmClips.Length > 0)
        { 
            canPlayMusic = true;
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying && canPlayMusic)
        {
            PlayMusic();
        }
    }

    void PlayMusic()
    {
        if (currentClip <= bgmClips.Length - 1)
        {
            audioSource.Stop();

            currentClip++;

            audioSource.Play();
        }
        if (currentClip > bgmClips.Length - 1)
        {
            audioSource.Stop();
            currentClip = 0;
            audioSource.Play();
        }
        audioSource.clip = bgmClips[currentClip];

        audioSource.Play();
    }

    public void StopMusic()
    {
        canPlayMusic = false;
        audioSource.Stop();
    }
}
