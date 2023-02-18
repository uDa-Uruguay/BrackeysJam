using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransporterController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float teleportDelay = 2f;
    private bool onTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!target) { Debug.Log("target not assign"); return;}
        if (other.CompareTag("Player"))
        {
            onTrigger = true;

            StartCoroutine(TeleportDelay(other));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }

    private IEnumerator TeleportDelay(Collider other)
    {
        yield return new WaitForSeconds(teleportDelay);
        if (onTrigger)
        {
            // Disable movement temporally. 
            PlayerMovement _movement = other.GetComponent<PlayerMovement>();
            if (_movement) _movement.enableMovement = false;
            else yield break;

            other.transform.position = target.transform.position;

            yield return new WaitForSeconds(0.5f);
            _movement.enableMovement = true;
        }
    }
}
