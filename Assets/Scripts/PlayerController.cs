using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void GetCaught(Vector3 direction, float force);
}

public class PlayerController : MonoBehaviour
{
    public float catchForce = 100f;

    private Camera mainCamera;
    private Animator animator;
    private void Awake()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("ThrowLine");
            
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                IEnemy enemy = hit.transform.GetComponent(typeof(IEnemy)) as IEnemy;
                if (enemy != null)
                {
                    enemy.GetCaught(mainCamera.transform.position, catchForce);
                }
            }
        }
    }
}
