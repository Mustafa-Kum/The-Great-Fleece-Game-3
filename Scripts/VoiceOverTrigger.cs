using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{

    public AudioClip clipToPlay;
    private bool audioCooldown;
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && audioCooldown == false)
        {

            AudioManager.Instance.PlayVoiceOver(clipToPlay);
            audioCooldown = true;

        }

    }

}
