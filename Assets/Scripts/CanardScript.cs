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

    public void SetVieCanard(int damage) {
        vieCanardVie = vieCanardVie - damage;
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
}
