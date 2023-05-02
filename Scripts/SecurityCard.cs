using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCard : MonoBehaviour
{
    public GameObject GuardCartCutscene; 
    
    void OnTriggerEnter(Collider other) 
    {
        
        if (other.tag == "Player")
        {

            GuardCartCutscene.SetActive(true);
            GameManager.Instance.HasCard = true;

        }

    }
}
