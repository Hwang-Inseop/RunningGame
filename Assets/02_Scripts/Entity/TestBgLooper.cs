using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestBgLooper : MonoBehaviour
{
    private const int bgCount = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Loopable")) return;
        
        Debug.Log("OnTriggerEnter2D : Loopable entered");
        var bgWidth = other.bounds.size.x;
        var bgOffset = new Vector3(bgWidth * bgCount, 0, 0);
        other.transform.position += bgOffset;
    }
}
