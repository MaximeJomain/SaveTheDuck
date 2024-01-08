using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour, IEnemy
{
    public float catchForce = 20f;
    
    private new Rigidbody rigidbody;
    private Camera mainCamera;
    private bool isDead;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void Start()
    {
        isDead = false;
    }

    public void GetCaught()
    {
        if (!isDead)
        {
            rigidbody.AddForce(mainCamera.transform.position * catchForce);
            Debug.Log("IEnemy " + transform.gameObject.name);
            isDead = true;
        }
    }
}
