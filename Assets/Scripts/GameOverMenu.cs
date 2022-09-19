using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public static bool gameIsPaused = true;
    public GameObject pauseMenuUI;
    private bool gameStarted = false;
    [SerializeField] private GameObject _button;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        
    }

    private void FixedUpdate()
    {
        if (ServiceLocator.Instance.GetService<Player>().isActiveAndEnabled==false)
        {
            GameOver();
        }
    }

    private void Start()
    {
        gameStarted = false;
        pauseMenuUI.SetActive(false);
        //_button.gameObject.SetActive(false);
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        _button.gameObject.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    private void GameOver()
    {
        pauseMenuUI.SetActive(true);
        _button.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        gameStarted = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}