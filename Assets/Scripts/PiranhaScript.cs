using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaScript : MonoBehaviour
{
    public int viePiranha = 1;

    public int degatPiranha = 10;

    public float vitessePiranha = 1f;


    public GameObject Canard;

    public Rigidbody RigidBodyPiranha;

    private void Awake()
    {
        Canard = GameObject.Find("Canard");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = new Vector3(Canard.transform.position.x - transform.position.x, RigidBodyPiranha.velocity.y, Canard.transform.position.z - transform.position.z);
        vector3.Normalize();
        RigidBodyPiranha.velocity = vector3 * vitessePiranha;


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
