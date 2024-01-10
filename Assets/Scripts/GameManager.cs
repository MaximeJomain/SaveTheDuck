using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private TMP_Text TMP_Timer;
    private float _elapsedTime;
    private bool _isPlaying;


    public string PlayScreen;
    public string MenuScreen;
    public GameObject GameOverScreen;

   
    public CanardScript Canard;

    private void Awake()
    {
        TMP_Timer = GameObject.Find("/Canvas/Timer").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        _elapsedTime = 0f;
        _isPlaying = true;
    }

    private void Update()
    {
        if (_isPlaying) {
            _elapsedTime += Time.deltaTime;

            if (Canard.isAlive() == false)
            {
                _isPlaying = false;
                GameOver();
            }
        }

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

    public void RePlay() {
        SceneManager.LoadScene(PlayScreen);
    }

    public void MainMenu() {
        SceneManager.LoadScene(MenuScreen);
    }

    public void GameOver() {
        Invoke("ShowGameOverScreen", 1f);
    }

    public void ShowGameOverScreen() {
        //m_LifeBar.gameObject.SetActive(false);
        GameOverScreen.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }
}
