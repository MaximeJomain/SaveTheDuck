using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanardScript : MonoBehaviour
{
    public float vieCanardVie = 100;

    public int vitesseCanard = 5;


    public Rigidbody RigidBodyCannard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        RigidBodyCannard.velocity = new Vector3(vitesseCanard * Input.GetAxis("Horizontal"), RigidBodyCannard.velocity.y, vitesseCanard * Input.GetAxis("Vertical"));
    }
}
