using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public float catchForce;
    
    private SphereCollider _sphereCollider;
    private Camera mainCamera;

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        mainCamera = Camera.main;
    }

    private void Start()
    {
        _sphereCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        IEnemy enemy = (IEnemy)other.transform.GetComponent(typeof(IEnemy));
        if (enemy != null)
        {
            enemy.GetCaught(mainCamera.transform.position, catchForce);
        }
    }

    public void ThrowHook(Vector3 position)
    {
        _sphereCollider.enabled = true;
        transform.position = position;
    }
}
