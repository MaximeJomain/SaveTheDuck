using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequinScript : MonoBehaviour, IEnemy
{
    public int vieRequin = 3;

    public int degatRequin = 50;

    public int vitesseRequin;


    private Transform Canard;
    private bool isDead;
    private new Rigidbody rigidbody;
    private new Collider collider;


    private void Awake()
    {
        Canard = GameObject.Find("Canard").transform;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        
        Vector3 playerPos = new Vector3(Canard.position.x, transform.position.y, Canard.position.z);
        transform.LookAt(playerPos);

        rigidbody.velocity = transform.forward * (vitesseRequin * Time.deltaTime);
    }

    public int GetVieRequin()
    {
        return vieRequin;
    }

    public int GetDegatRequin()
    {
        return degatRequin;
    }

    public void SetVieRequin(int degat)
    {
        vieRequin = vieRequin - degat;
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
