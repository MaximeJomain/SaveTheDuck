using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaScript : MonoBehaviour
{
    public int viePiranha = 1;

    public int degatPiranha = 10;

    public float vitessePiranha = 1f;
    
    private Transform Canard;
    private Rigidbody RigidBodyPiranha;

    private void Awake()
    {
        Canard = GameObject.Find("Canard").transform;
        RigidBodyPiranha = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Vector3 playerPos = new Vector3(Canard.position.x, transform.position.y, Canard.position.z);
        transform.LookAt(playerPos);
        
    }

    public int GetViePiranha()
    {
        return viePiranha;
    }

    public int GetDegatPiranha()
    {
        return degatPiranha;
    }

    public void SetViePiranha(int degat)
    {
        viePiranha = viePiranha - degat;
    }
}
