using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Slider brightnessSlider;
    public Slider textSizeSlider;
    public Slider volumeSlider;
    public Slider contrastSlider;
    public TMP_Dropdown difficultyDropdown;
    private string previousScene;
    void Start()
    {
        brightnessSlider.onValueChanged.AddListener(SetBrightness);
        contrastSlider.onValueChanged.AddListener(SetContrast);
        textSizeSlider.onValueChanged.AddListener(SetTextSize);
        volumeSlider.onValueChanged.AddListener(SetVolume);
        difficultyDropdown.onValueChanged.AddListener(SetDifficulty);
        previousScene = PlayerPrefs.GetString("PreviousScene", "Main_Menu");
        
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
        contrastSlider.value = PlayerPrefs.GetFloat("Contrast");
        textSizeSlider.value = PlayerPrefs.GetFloat("TextSize");
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty");
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void BackToPreviousScene()
    {
        if (!string.IsNullOrEmpty(previousScene) && previousScene != "Settings")
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }

    public static void SetPreviousScene(string sceneName)
    {
        PlayerPrefs.SetString("PreviousScene", sceneName);
        PlayerPrefs.Save();
    } 
    void SetBrightness(float value)
    {
        PlayerPrefs.SetFloat("Brightness", value);
        PlayerPrefs.Save();
        Debug.Log("Brightness set to: " + value);
    }

    void SetContrast(float value)
    {
        PlayerPrefs.SetFloat("Contrast", value);
        PlayerPrefs.Save();
        Debug.Log("Contrast set to: " + value);
    }

    void SetTextSize(float value)
    {
        PlayerPrefs.SetFloat("TextSize", value);
        PlayerPrefs.Save();
        Debug.Log("Text size set to: " + value);
    }

    void SetVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
        AudioListener.volume = value;
        Debug.Log("Volume set to: " + value);
    }

    void SetDifficulty(int index)
    {
        PlayerPrefs.SetInt("Difficulty", index);
        PlayerPrefs.Save();
        string difficulty = difficultyDropdown.options[index].text;
        Debug.Log("Difficulty set to: " + difficulty);
    }

    void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Brightness"))
        {
            brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
        }
        if (PlayerPrefs.HasKey("Contrast"))
        {
            brightnessSlider.value = PlayerPrefs.GetFloat("Contrast");
        }
        if (PlayerPrefs.HasKey("TextSize"))
        {
            textSizeSlider.value = PlayerPrefs.GetFloat("TextSize");
        }
        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty");
        }
    }
    
}







