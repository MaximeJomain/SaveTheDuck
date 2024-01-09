using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanardScript : MonoBehaviour
{
    public float vieCanardVie = 100;

    public int vitesseCanard = 1;


    public Rigidbody RigidBodyCanard;
    public GameObject Canard;

    private void Awake()
    {
        Canard = GameObject.Find("Canard");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //RigidBodyCannard.velocity = new Vector3(vitesseCanard * Input.GetAxis("Horizontal"), RigidBodyCannard.velocity.y, vitesseCanard * Input.GetAxis("Vertical"));

        if (Canard.transform.position.z >= 0.3f && Canard.transform.position.x > (-0.9f))
        {
            RigidBodyCanard.velocity = new Vector3(vitesseCanard * (-0.1f), RigidBodyCanard.velocity.y, RigidBodyCanard.velocity.z);
            Canard.transform.rotation = Quaternion.Euler(0, 270, 0);
        }


        if (Canard.transform.position.x <= (-0.9f) && Canard.transform.position.z > (-0.3f))
        {
            RigidBodyCanard.velocity = new Vector3(RigidBodyCanard.velocity.x, RigidBodyCanard.velocity.y, vitesseCanard * (-0.1f));
            Canard.transform.rotation = Quaternion.Euler(0, 180, 0);
        }


        if (Canard.transform.position.z <= (-0.3f) && Canard.transform.position.x < (0.9f))
        {
            RigidBodyCanard.velocity = new Vector3(vitesseCanard * 0.1f, RigidBodyCanard.velocity.y, RigidBodyCanard.velocity.z);
            Canard.transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Canard.transform.position.x >= (0.9f) && Canard.transform.position.z < (0.3f))
        {
            RigidBodyCanard.velocity = new Vector3(RigidBodyCanard.velocity.x, RigidBodyCanard.velocity.y, vitesseCanard * (0.1f));
            Canard.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
