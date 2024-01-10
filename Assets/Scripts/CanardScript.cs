using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanardScript : MonoBehaviour
{
    public int MaxVieCanard = 100;
    public int vieCanardVie = 100;

    public bool _isAlive = true;

    public TMP_Text TMP_VieCanard;

    private void Awake() 
    {
        TMP_VieCanard = GameObject.Find("/Canard/Canvas/Vie").GetComponent<TMP_Text>();
    }

    void Update()
    {
        vieCanardVie = Mathf.Clamp(vieCanardVie, 0, MaxVieCanard);
        TMP_VieCanard.text = vieCanardVie + " / " + MaxVieCanard;
    }

    public int GetVieCanard() {
        return vieCanardVie;
    }

    public void SetVieCanard(int domage) {
        vieCanardVie = vieCanardVie - domage;
    }

    public bool isAlive() {
        if (vieCanardVie > 0) {
            _isAlive = true;
        }
        else {
            _isAlive = false;
        }
        return _isAlive;
    }

    void OnCollisionEnter(Collision collision) {
        //Debug.Log("Toucher");
        //this.SetVieCanard(110);

        if (collision.gameObject.name == "Piranha(Clone)")
        {
            Debug.Log("Pirana");
            this.SetVieCanard(10);
        }

        if (collision.gameObject.name == "Anguille(Clone)")
        {
            Debug.Log("Anguille");
            this.SetVieCanard(25);
        }

        if (collision.gameObject.name == "Requin(Clone)")
        {
            Debug.Log("Requin");
            this.SetVieCanard(50);
        }
    }
}
