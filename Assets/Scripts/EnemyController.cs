using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemy
{
    private new Rigidbody rigidbody;
    private bool isDead;
    private new Collider collider;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        isDead = false;
    }

    public void GetCaught(Vector3 direction, float force)
    {
        if (!isDead)
        {
            collider.enabled = false;
            rigidbody.AddForce(transform.position + direction * force);
            Debug.Log("IEnemy " + transform.gameObject.name);
            isDead = true;
            
            Destroy(gameObject, 2f);
        }
    }
}
