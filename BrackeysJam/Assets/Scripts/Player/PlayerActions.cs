using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private float number = 0f;
    private float target = 1f;
    private void Update()
    {
        number = Mathf.MoveTowards(number, target, 0.5f * Time.deltaTime);
        if (number == 1) return;
        Debug.Log("Moving. Current number:" + number);
    }
}
