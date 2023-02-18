using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    [SerializeField] private BoolVariable gotObject;
    [SerializeField] private GameEvent gotObjectEvent;

    private void OnTriggerEnter(Collider other)
    {
        gotObject.value = true;
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1f);
        gotObjectEvent.Raise();
        Destroy(this.gameObject);
    }
}
