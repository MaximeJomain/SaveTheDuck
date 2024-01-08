using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckController : MonoBehaviour, IEnemy
{
    private new Rigidbody rigidbody;
    private bool isDead;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        isDead = false;
    }

    public void GetCaught(Vector3 direction, float force)
    {
        if (!isDead)
        {
            rigidbody.AddForce(direction * force);
            Debug.Log("IEnemy " + transform.gameObject.name);
            isDead = true;
        }
    }
}
