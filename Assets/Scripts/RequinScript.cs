using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequinScript : MonoBehaviour
{
    public int vieRequin = 3;

    public int degatRequin = 50;

    public int vitesseRequin = 3;


    public Rigidbody RigidBodyRequin;

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
    void Update()
    {
        Vector3 vector3 = new Vector3(Canard.transform.position.x - transform.position.x, RigidBodyRequin.velocity.y, Canard.transform.position.z - transform.position.z);
        vector3.Normalize();
        RigidBodyRequin.velocity = vector3 * vitesseRequin;
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
}
