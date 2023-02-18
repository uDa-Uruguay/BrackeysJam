using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class GrabbingAreaController : MonoBehaviour
{  
    [SerializeField] private GameEvent eventGrab;
    [SerializeField] private GameEvent eventDrop;
    private bool isGrabbing = false;
    
    private void Update()
    {
        if (isGrabbing && Input.GetKeyUp(KeyCode.Z))
        {
            isGrabbing = false;
            if (eventDrop) eventDrop.Raise();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Orb"))
        {
            if (Input.GetKey(KeyCode.Z) && isGrabbing == false)
            {
                isGrabbing = true;
                if(eventGrab) eventGrab.Raise();
            } 
        }
    }
}
