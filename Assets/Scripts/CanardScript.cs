using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CanardScript : MonoBehaviour
{
    public int MaxVieCanard = 100;
    [FormerlySerializedAs("vieCanardVie")]
    public int Health = 100;

    public bool _isAlive = true;

    void Update()
    {
        Health = Mathf.Clamp(Health, 0, MaxVieCanard);
    }

    public int GetVieCanard() {
        return Health;
    }

    public void SetVieCanard(int damage) {
        Health = Health - damage;
    }

    public bool isAlive() {
        if (Health > 0) {
            _isAlive = true;
        }
        else {
            _isAlive = false;
        }
        return _isAlive;
    }
}
