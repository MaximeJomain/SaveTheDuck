using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnguilleScript : MonoBehaviour, IEnemy
{
    public int vieAnguille = 2;
    public int damage;
    public int scoreValue;
    public AudioClip attackSound;
    public TextMesh floatingText;

    
    private AudioSource _audioSource;

    public int vitesseAnguille;
    
    private Transform Canard;
    private Rigidbody RigidBodyAnguille;
    private bool isDead;
    private new Rigidbody rigidbody;
    private new Collider collider;
    private bool canAttack;
    private GameManager gameManager;
    private Camera mainCamera;


    private void Awake()
    {
        Canard = GameObject.Find("Canard").transform;
        RigidBodyAnguille = GetComponent<Rigidbody>();
        
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        mainCamera = Camera.main;
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
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        RigidBodyAnguille.velocity = transform.forward * (vitesseAnguille * Time.fixedDeltaTime);
    }

    public int GetVieAnguille()
    {
        return vieAnguille;
    }

    public void SetVieAnguille(int degat)
    {
        vieAnguille = vieAnguille - degat;
    }

    public void GetCaught(Vector3 direction, float force)
    {
        if (!isDead)
        {
            isDead = true;
            var instance = Instantiate(floatingText, transform.position, Quaternion.LookRotation(mainCamera.transform.position - transform.position, Vector3.forward));
            instance.GetComponent<TextMesh>().text = "+" + scoreValue;
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
