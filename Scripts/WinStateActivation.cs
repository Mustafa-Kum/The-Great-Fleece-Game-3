using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    public GameObject WinCutscene; 
    
    void OnTriggerEnter(Collider other) 
    {
        
        if (other.tag == "Player")
        {

            if (GameManager.Instance.HasCard == true)
            {
            
                WinCutscene.SetActive(true);

            }
            else
            {

                Debug.Log("Grab KeyCard");

            }

        }

    }
}
