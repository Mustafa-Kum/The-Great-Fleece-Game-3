using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{

    public GameObject gameOverCutscene;
    public AudioClip clipToPlay;
    private bool GameOverCooldown;
    
    void OnTriggerEnter(Collider other) 
    {
        
        if (other.tag == "Player" && GameOverCooldown == false)
        {

            AudioManager.Instance.PlayVoiceOverStop(clipToPlay);
            GameOverCooldown = true;
            gameOverCutscene.SetActive(true);

        }

    }

}
