using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextController : MonoBehaviour
{
    private TextMeshProUGUI thisText;

    private void Start()
    {
        thisText = this.gameObject.GetComponent<TextMeshProUGUI>();
        if (!thisText) { Debug.Log("No text field assign in " + this.name); return; }
    }

    public void UpdateState()
    {
        if (!thisText) return;
        thisText.color = Color.green;
    }
}
