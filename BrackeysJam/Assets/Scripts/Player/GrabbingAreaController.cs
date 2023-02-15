using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabbingAreaController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    { 
        if(collision.collider.CompareTag("Orb"))
        {
            Debug.Log("Working");
        }
    }
}
