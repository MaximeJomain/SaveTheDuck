using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider _healthBar;
    
    [SerializeField]
    private Slider _easeHealthBar;
    
    private CanardScript _target;
    


    private void Awake()
    {
        _target = GameObject.Find("Canard").GetComponent<CanardScript>();
    }

    private void Start()
    {
        _healthBar.maxValue = _target.Health;
        _easeHealthBar.maxValue = _target.Health;
    }

    private void Update()
    {
        if (_healthBar.value != _target.Health)
        {
            _healthBar.value = _target.Health;
        }

        if (_easeHealthBar.value != _healthBar.value)
        {
            _easeHealthBar.value = Mathf.Lerp(_easeHealthBar.value, _target.Health, 0.025f);
        }
    }
}
