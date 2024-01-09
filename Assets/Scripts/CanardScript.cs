using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanardScript : MonoBehaviour
{
    public float vieCanardVie = 100;

    public float vitesseCanard = 1f;
    
    public GameObject Canard;

    private void Awake()
    {
        Canard = GameObject.Find("Canard");
    }

    void Start()
    {
        vitesseCanard /= 25;
    }


    private void Update()
    {

        if (Canard.transform.position.z >= 0.6f && Canard.transform.position.x > (-2.25f))
        {
            Canard.transform.rotation = Quaternion.Euler(0, 270, 0);
            Canard.transform.Translate(0, 0, vitesseCanard * 0.01f);
        }
        
        
        if (Canard.transform.position.x <= (-2.25f) && Canard.transform.position.z > (-0.6f))
        {
            Canard.transform.rotation = Quaternion.Euler(0, 180, 0);
            Canard.transform.Translate(0, 0, vitesseCanard * 0.01f);
        }
        
        
        if (Canard.transform.position.z <= (-0.6f) && Canard.transform.position.x < (2.25f))
        {
            Canard.transform.rotation = Quaternion.Euler(0, 90, 0);
            Canard.transform.Translate(0, 0, vitesseCanard * 0.01f);
        }
        
        if (Canard.transform.position.x >= (2.25f) && Canard.transform.position.z < (0.6f))
        {
            Canard.transform.rotation = Quaternion.Euler(0, 0, 0);
            Canard.transform.Translate(0, 0, vitesseCanard * 0.01f);
        }
    }
}
