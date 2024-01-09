using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TMP_Text TMP_Timer;
    private float _elapsedTime;
    private bool _isGameOver;

    private void Awake()
    {
        TMP_Timer = GameObject.Find("/Canvas/Timer").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _elapsedTime = 0f;
        _isGameOver = false;
    }

    private void Update()
    {
        if (!_isGameOver)
            _elapsedTime += Time.deltaTime;
        
        handleGUI();
    }
    
    private void handleGUI()
    {
        // update Timer
        int minutes = Mathf.FloorToInt(_elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(_elapsedTime - minutes * 60);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        TMP_Timer.text = formattedTime;
    }
}
