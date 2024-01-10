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
    public GameObject fishingRod;
    public Transform lineStart;
    public GameObject hookPrefab;
    
    private Camera mainCamera;
    private LineRenderer fishLine;
    private Vector3 v1, v2;
    private Hook hook;
    private Animator fishingRodAnimator;
    
    [Header("Fishing Rod Settings")]
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float setY;
    public float rodSpeed;

    private void Awake()
    {
        mainCamera = Camera.main;
        hook = hookPrefab.GetComponent<Hook>();
        fishingRodAnimator = fishingRod.GetComponent<Animator>();
    }

    private void Start()
    {
        rodSpeed /= 100;
        
        fishLine = fishingRod.gameObject.AddComponent<LineRenderer>();
        v1 = lineStart.position;
        v2 = hookPrefab.transform.position;
        fishLine.SetColors(Color.green, Color.green);
        fishLine.SetWidth(0.005f, 0.007f);
        fishLine.SetVertexCount(2);
        fishLine.SetPosition(0, v1);
        fishLine.SetPosition(1, v2);
        fishLine.material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    }

    private void Update()
    {
        MoveMouse();
        HandleFishing();
    }

    private void HandleFishing()
    {
        v1 = lineStart.position;
        fishLine.SetPosition(0, v1);
        v2 = hookPrefab.transform.position;
        fishLine.SetPosition(1, v2);

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)
            && hook.canThrow
            && Physics.Raycast(ray, out RaycastHit hit, 100))
        {
            Debug.Log("RAYCAST " + hit.transform.gameObject.name);
            if (hit.transform.CompareTag("Water")
                || hit.transform.CompareTag("Enemy"))
            {
                StartCoroutine(FishAction(hit.point, fishingRodAnimator));
                // StartCoroutine(FishAction(hit.point));
            }
        }
    }

    private IEnumerator FishAction(Vector3 hitInfoPoint, Animator animator)
    {
        hook.canThrow = false;
        fishingRodAnimator.SetTrigger("ThrowLine");
        yield return new WaitForSeconds(.3f);
        hook.MoveToTarget(hitInfoPoint, animator);
    }

    // private IEnumerator FishAction(Vector3 target)
    // {
    //     fishingRodAnimator.SetTrigger("ThrowLine");
    //     
    //     yield return new WaitForSeconds(.3f);
    //     hook.ThrowHook(target, fishingRodAnimator);
    // }

    private void MoveMouse()
    {
        fishingRod.transform.position =
            new Vector3(fishingRod.transform.position.x, setY, fishingRod.transform.position.z);
        
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
