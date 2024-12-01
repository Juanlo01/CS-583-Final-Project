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
        previousScene = PlayerPrefs.GetString("previousScene", "Main_Menu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void BackToPreviousScene()
    {
        SceneManager.LoadScene(previousScene);
    }
    void SetBrightness(float value)
    {
        PlayerPrefs.SetFloat("Brightness", value);
        Debug.Log("Brightness set to: " + value);
    }

    void SetContrast(float value)
    {
        PlayerPrefs.SetFloat("Contrast", value);
        Debug.Log("Contrast set to: " + value);
    }

    void SetTextSize(float value)
    {
        PlayerPrefs.SetFloat("TextSize", value);
        Debug.Log("Text size set to: " + value);
    }

    void SetVolume(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);
        AudioListener.volume = value;
        Debug.Log("Volume set to: " + value);
    }

    void SetDifficulty(int index)
    {
        PlayerPrefs.SetInt("Difficulty", index);
        string difficulty = difficultyDropdown.options[index].text;
        Debug.Log("Difficulty set to: " + difficulty);
    }
    
}







