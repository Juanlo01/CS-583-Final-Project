using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Character_Selection");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level_Select_Menu");
    }

    public void Directions()
    {
        SceneManager.LoadScene("Directions");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
