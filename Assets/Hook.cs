using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [Header("Params")]
    public float catchForce;
    public Transform lineEnd;
    public float throwSpeed;
    public float throwCooldown;
    
    [Header("Audio")]
    public AudioClip catchSFX;
    private AudioSource audioSource;
    
    [HideInInspector]
    public bool canThrow;
    
    private SphereCollider _sphereCollider;
    private Camera mainCamera;
    private Animator fishingRodAnimator;
    private bool isThrow;
    private Vector3 targetPosition;

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        mainCamera = Camera.main;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _sphereCollider.enabled = false;
        isThrow = false;
        canThrow = true;
    }

    private void Update()
    {
        if (!isThrow)
        {
            transform.position = Vector3.Lerp(transform.position, lineEnd.position, throwSpeed * 0.5f * Time.deltaTime);
        }

        if (isThrow)
        {
            // transform.position = targetPosition;
            transform.position = Vector3.Lerp(transform.position, targetPosition, throwSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IEnemy enemy = (IEnemy)other.transform.GetComponent(typeof(IEnemy));
        if (enemy != null)
        {
            if (fishingRodAnimator)
            {
                fishingRodAnimator.SetTrigger("Catch");
            }
            audioSource.PlayOneShot(catchSFX);
            enemy.GetCaught(mainCamera.transform.position, catchForce);
            DisableThrow();
        }
        else
        {
            DisableThrow();
        }
    }

    private void DisableThrow()
    {
        isThrow = false;
        targetPosition = Vector3.zero;
        _sphereCollider.enabled = false;
        Invoke("setCanThrowTrue", throwCooldown);
    }

    public void MoveToTarget(Vector3 hitInfoPoint, Animator animator)
    {
        if (!fishingRodAnimator)
        {
            fishingRodAnimator = animator;
        }

        isThrow = true;
        targetPosition = hitInfoPoint;
        _sphereCollider.enabled = true;
    }

    private void setCanThrowTrue()
    {
        canThrow = true;
    }
}
