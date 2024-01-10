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
    public GameObject PauseScreen;
    public GameObject Audio;


    private CanardScript Canard;

    public bool Pause;

    public TMP_Text HighScoreText;
    private float HighScore;

    private void Awake()
    {
        TMP_Timer = GameObject.Find("/Canvas/Timer").GetComponent<TMP_Text>();
        Canard = GameObject.Find("Canard").GetComponent<CanardScript>();
    }

    private void Start()
    {
        PauseScreen.SetActive(false);
        Audio.gameObject.SetActive(true);
        Time.timeScale = 1f;
        _elapsedTime = 0f;
        _isPlaying = true;

        HighScore = PlayerPrefs.GetFloat("HighScore", HighScore);
    }

    private void Update()
    {
        if (_isPlaying) {
            _elapsedTime += Time.deltaTime;

            if (HighScore < Time.deltaTime)
            {
                HighScore = Time.deltaTime;
            }
            UpdateHighScore();

            if (Canard.isAlive() == false)
            {
                _isPlaying = false;
                Audio.gameObject.SetActive(false);
                GameOver();
            }
        }

        handleGUI();
        EnPause();
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

    public void EnPause()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) {
            Pause = !Pause;

            if (Pause)
            {
                Time.timeScale = 0f;
                PauseScreen.SetActive(true);
                Audio.gameObject.SetActive(false);
            }
            else
            {
                PauseScreen.SetActive(false);
                Audio.gameObject.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.SetFloat("HighScore", HighScore);
        PlayerPrefs.Save();
    }

    public void UpdateHighScore()
    {
        HighScoreText.SetText("High Score : {0:00}:{1:00}", HighScore);
    }
}
