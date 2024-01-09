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
    public GameObject fishingRod;
    public Transform lineStart;
    public GameObject scriptTarget;

    [Header("Fishing Rod Settings")]
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float rodSpeed;

    private Camera mainCamera;
    private Animator animator;
    private LineRenderer fishLine;
    private Vector3 v1, v2;

    private void Awake()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        rodSpeed /= 100;
        
        fishLine = fishingRod.gameObject.AddComponent<LineRenderer>();
        v1 = lineStart.position;
        v2 = scriptTarget.transform.position;
        fishLine.SetColors(Color.green, Color.green);
        fishLine.SetWidth(0.005f, 0.007f);
        fishLine.SetVertexCount(2);
        fishLine.SetPosition(0, v1);
        fishLine.SetPosition(1, v2);
        fishLine.material = new Material(Shader.Find("Diffuse"));
    }

    private void Update()
    {
        MoveMouse();
        
        v1 = lineStart.position;
        fishLine.SetPosition (0, v1);
        v2 = scriptTarget.transform.position;
        fishLine.SetPosition (1, v2);
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)
            && Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            if (hit.transform.CompareTag("Water")
                 || hit.transform.CompareTag("Enemy"))
            {
                animator.SetTrigger("ThrowLine");
                scriptTarget.transform.position = hit.point;
                
                IEnemy enemy = hit.transform.GetComponent(typeof(IEnemy)) as IEnemy;
                if (enemy != null)
                {
                    enemy.GetCaught(mainCamera.transform.position, catchForce);
                }
            }
        }
    }

    private void MoveMouse()
    {
        if (Input.GetAxis("Mouse X") > 0 
            || Input.GetAxis("Mouse X") < 0)
        {
            fishingRod.transform.position += new Vector3(Input.GetAxis("Mouse X") * rodSpeed, 0f, 0f);
            var pos = fishingRod.transform.position;
            pos.x = Mathf.Clamp(fishingRod.transform.position.x, minX, maxX);
            fishingRod.transform.position = pos;
        }
        
        
        if (Input.GetAxis("Mouse Y") > 0 
            || Input.GetAxis("Mouse Y") < 0)
        {
            fishingRod.transform.position += new Vector3(0f, 0f, Input.GetAxis("Mouse Y") * rodSpeed);
            var pos = fishingRod.transform.position;
            pos.z = Mathf.Clamp(fishingRod.transform.position.z, minZ, maxZ);
            fishingRod.transform.position = pos;
        }
    }
}
