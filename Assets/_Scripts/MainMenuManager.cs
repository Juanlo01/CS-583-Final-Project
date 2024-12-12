using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void CharacterSelection()
    {
        SceneManager.LoadScene("Character_Selection");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level_Select_Menu");
    }

    public void Level1(){
        SceneManager.LoadScene("Map1");
    }

    public void Directions()
    {
        SceneManager.LoadScene("Directions");
    }

    public void Settings()
    {
        PlayerPrefs.SetString("PreviousScene", "Main_Menu");
        SceneManager.LoadScene("Settings_Menu");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}