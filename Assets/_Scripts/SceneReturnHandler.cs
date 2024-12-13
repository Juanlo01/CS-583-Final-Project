using UnityEngine;

public class SceneReturnHandler : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the Pause Menu
    public GameObject userInterface; // Reference to the in-game UI

    void Start()
    {
        // Check if returning from the settings menu
        string previousScene = PlayerPrefs.GetString("PreviousScene", "");
        if (previousScene == "Settings_Menu" && pauseMenuUI != null)
        {
            // Activate the Pause Menu
            pauseMenuUI.SetActive(true);
            if (userInterface != null) userInterface.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}





