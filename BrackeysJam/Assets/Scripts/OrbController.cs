using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    [Header("Interactions")]
    [SerializeField] private Transform targetPosition;
    private bool isGrabbed = false;
    private float currentT = 0f; // Works with the Lerp of movement. Values 0 to 1 only.
    [SerializeField] private float _moveSpeed = 0.5f;

    private void Update()
    {
        if (isGrabbed) this.transform.position = targetPosition.position; // If object was already grabbed, this just maintains the object in place.
        
        if(Input.GetKeyDown(KeyCode.Z)) OrbGrabbed();
        if(Input.GetKeyUp(KeyCode.Z)) OrbDropped();
    }

    private void OrbGrabbed()
    {
        if (!targetPosition || isGrabbed) return;

        isGrabbed = true;
        
        while (currentT != 1)
        {
            currentT = Mathf.MoveTowards(currentT, 1f, _moveSpeed * Time.deltaTime); // Changes currentT from 0 to 1.

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition.position, currentT);
        }
        
        currentT = 0f; 
    }

    private void OrbDropped()
    {
        isGrabbed = false;
    }
}
