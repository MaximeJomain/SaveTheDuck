using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaScript : MonoBehaviour, IEnemy
{
    public int viePiranha = 1;

    public float vitessePiranha;
    
    private Transform Canard;
    private Rigidbody RigidBodyPiranha;
    private bool isDead;
    private new Rigidbody rigidbody;
    private new Collider collider;

    private void Awake()
    {
        Canard = GameObject.Find("Canard").transform;
        RigidBodyPiranha = GetComponent<Rigidbody>();
        
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        isDead = false;
    }

    void Update()
    {
        if (isDead) return;
        
        Vector3 playerPos = new Vector3(Canard.position.x, transform.position.y, Canard.position.z);
        transform.LookAt(playerPos);

        RigidBodyPiranha.velocity = transform.forward * (vitessePiranha * Time.deltaTime);
    }

    public int GetViePiranha()
    {
        return viePiranha;
    }

    public void SetViePiranha(int degat)
    {
        viePiranha = viePiranha - degat;
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
