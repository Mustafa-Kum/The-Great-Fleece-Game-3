using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    
    public Transform target;
    public Transform startCamera;

    void Start()
    {

        transform.position = startCamera.position;
        transform.rotation = startCamera.rotation;

    }
    
    void Update()
    {

        transform.LookAt(target);

    }
}
