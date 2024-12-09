using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject mainMenuUI;
    private bool isPaused = false;
    
    void Start()
    {
        if (pauseMenuUI == null)
        {
            pauseMenuUI = GameObject.Find("PauseMenu");
            if (pauseMenuUI == null)
            {
                Debug.LogWarning("PauseMenuUI not found in Scene");
            }
        }

        if (mainMenuUI == null)
        {
            mainMenuUI = GameObject.Find("MainGUI");
            if (mainMenuUI == null)
            {
                Debug.LogWarning("MainGUI not found in Scene");
            }
        }
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
        if (mainMenuUI != null) mainMenuUI.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape Key Pressed");
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
        if (mainMenuUI != null) mainMenuUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        if (pauseMenuUI != null)pauseMenuUI.SetActive(true);
        if (mainMenuUI != null)mainMenuUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }

    public void Directions()
    {
        SceneManager.LoadScene("Directions");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exited Game");
    }

    public void Settings()
    {
        //Saves this scene as the previous scene.
        //PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        SettingsManager.SetPreviousScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Settings_Menu");
    }
    
}



