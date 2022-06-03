using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PAUSE_MENU : MonoBehaviour
{
    public static bool _gameIsPaused = false;

    public GameObject _pauseMenuUI, _confUpdateRings, _infoMenu;

    private void Start()
    {
        _gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        _gameIsPaused = true;
        _pauseMenuUI.SetActive(true);
    }

    public void Resume()
    {       
        _pauseMenuUI.SetActive(false);
        _gameIsPaused = false;
    }
    public void OpenConfUpdateRings()
    {
        _gameIsPaused = true;
        _confUpdateRings.SetActive(true); 
    }

    public void CloseConfUpdateRings()
    {
        _confUpdateRings.SetActive(false);
        _gameIsPaused = false;       
    }

    public void InfoMenuOpen()
    {
        _pauseMenuUI.SetActive(false);
        _infoMenu.SetActive(true);
    }

    public void InfoMenuClose()
    {
        _infoMenu.SetActive(false);
        _pauseMenuUI.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
