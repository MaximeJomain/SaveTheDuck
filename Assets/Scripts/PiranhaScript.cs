using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaScript : MonoBehaviour, IEnemy
{
    public int viePiranha = 1;
    public int damage;
    public int scoreValue;

    public float vitessePiranha;
    
    private Transform Canard;
    private Rigidbody RigidBodyPiranha;
    private bool isDead;
    private new Rigidbody rigidbody;
    private new Collider collider;
    private GameManager gameManager;
    
    public AudioClip attackSound;
    private AudioSource _audioSource;
    
    private bool canAttack;

    private void Awake()
    {
        Canard = GameObject.Find("Canard").transform;
        RigidBodyPiranha = GetComponent<Rigidbody>();
        
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Start()
    {
        canAttack = true;
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
            isDead = true;
            gameManager.Score += scoreValue;
            collider.enabled = false;
            rigidbody.AddForce(transform.position + direction * force);
            Destroy(gameObject, 2f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Duck")
            && canAttack)
        {
            canAttack = false;
            CanardScript canardScript = other.gameObject.GetComponent<CanardScript>();
            canardScript.SetVieCanard(damage);
            _audioSource.PlayOneShot(attackSound);
            Invoke("resetCanAttack", 2f);
        }
    }

    private void resetCanAttack()
    {
        canAttack = true;
    }
}
