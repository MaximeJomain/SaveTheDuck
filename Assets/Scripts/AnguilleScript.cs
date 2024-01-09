using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnguilleScript : MonoBehaviour
{
    public int vieAnguille = 2;

    public int degatAnguille = 25;

    public int vitesseAnguille = 2;


    public GameObject Canard;

    public Rigidbody RigidBodyAnguille;


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
        Vector3 vector3 = new Vector3(Canard.transform.position.x - transform.position.x, RigidBodyAnguille.velocity.y, Canard.transform.position.z - transform.position.z);
        vector3.Normalize();
        RigidBodyAnguille.velocity = vector3 * vitesseAnguille;
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
}
