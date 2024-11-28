using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonSound;  // Drag your button sound here
    private Button button;
    private Color originalColor;

    void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            originalColor = button.colors.normalColor;
            button.onClick.AddListener(PlayButtonSound);

        }
    }

    void PlayButtonSound()
    {
        // Use SoundManager to play the button sound
        if (ButtonSoundManager.instance != null && buttonSound != null)
        {
            ButtonSoundManager.instance.PlaySound(buttonSound);
            Debug.Log("ButtonSound Played");
        }
    }
    
}




