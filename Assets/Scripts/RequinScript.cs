using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequinScript : MonoBehaviour, IEnemy
{
    public int vieRequin = 3;
    public int damage;
    public int vitesseRequin;
    public int scoreValue;

    private Transform Canard;
    private bool isDead;
    private new Rigidbody rigidbody;
    private new Collider collider;
    private GameManager gameManager;
    
    private AudioSource _audioSource;
    public AudioClip attackSound;
    private bool canAttack;

    private void Awake()
    {
        Canard = GameObject.Find("Canard").transform;
        rigidbody = GetComponent<Rigidbody>();
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

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        
        Vector3 playerPos = new Vector3(Canard.position.x, transform.position.y, Canard.position.z);
        transform.LookAt(playerPos);

    }

    private void FixedUpdate()
    {
        if (isDead) return;

        rigidbody.velocity = transform.forward * (vitesseRequin * Time.fixedDeltaTime);
    }

    public int GetVieRequin()
    {
        return vieRequin;
    }

    public void SetVieRequin(int degat)
    {
        vieRequin = vieRequin - degat;
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
