using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnguilleScript : MonoBehaviour, IEnemy
{
    public int vieAnguille = 2;

    public int degatAnguille = 25;

    public int vitesseAnguille;


    private Transform Canard;
    private Rigidbody RigidBodyAnguille;
    private bool isDead;
    private new Rigidbody rigidbody;
    private new Collider collider;


    private void Awake()
    {
        Canard = GameObject.Find("Canard").transform;
        RigidBodyAnguille = GetComponent<Rigidbody>();
        
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

        RigidBodyAnguille.velocity = transform.forward * (vitesseAnguille * Time.deltaTime);
    }

    public int GetVieAnguille()
    {
        return vieAnguille;
    }

    public int GetDegatAnguille()
    {
        return degatAnguille;
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
            collider.enabled = false;
            rigidbody.AddForce(transform.position + direction * force);
            
            Destroy(gameObject, 2f);
        }
    }
}
