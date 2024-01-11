using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float timeToDestroy;
    
    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
