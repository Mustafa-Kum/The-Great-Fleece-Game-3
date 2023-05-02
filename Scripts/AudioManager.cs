using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioManager _instance;
    public static AudioManager Instance
    {

        get
        {

            if (_instance == null)
            {

                Debug.LogError(" Audio Manager is null !! ");

            }

            return _instance;

        }

    }

    public AudioSource voiceOver;
    private bool AudioCooldown;
    private AudioClip lastClipPlayed;

    private void Awake()
    {

        _instance = this;

    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {

        if (AudioCooldown == false)
        {

            voiceOver.clip = clipToPlay;
            voiceOver.Play();

        }

    }

    public void PlayVoiceOverStop(AudioClip clipToPlay)
    {

        if (AudioCooldown == false)
        {

            voiceOver.clip = clipToPlay;
            voiceOver.Stop();

        }

    }

}
