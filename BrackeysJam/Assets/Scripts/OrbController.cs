using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    [SerializeField] private CurrentOrb _currentOrb;

    [Header("Interactions")]
    [SerializeField] private Transform targetPosition;
    private bool isGrabbed = false;
    [SerializeField] private AnimationCurve _moveEase;
    [SerializeField] private float _moveSpeed = 0.5f;
    private void Update()
    {
        if (isGrabbed) this.transform.position = targetPosition.position; // If object was already grabbed, this just maintains the object in place.
    }

    public void OrbGrabbed()
    {
        if (!targetPosition || isGrabbed) {Debug.Log("Target not assign"); return;}

        isGrabbed = true;
        _currentOrb.orbType = Orbs.VIOLET;
        LeanTween.move(this.gameObject, targetPosition, _moveSpeed).setEase(_moveEase); 
    }

    public void OrbDropped()
    {
        isGrabbed = false;
        _currentOrb.orbType = Orbs.NONE;
    }
}
