using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{

    public GameObject gameOverCutscene;
    public Animator _anim;
    
    void OnTriggerEnter(Collider other) 
    {
        
        if (other.tag == "Player")
        {

            MeshRenderer render = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f,.1f,.1f,.3f);
            render.material.SetColor("_TintColor", color);
            _anim.enabled = false;
            StartCoroutine(CameraCoolDown());

        }

    }

    IEnumerator CameraCoolDown()
    {

        yield return new WaitForSeconds(0.5f);
        gameOverCutscene.SetActive(true);

    }

}
