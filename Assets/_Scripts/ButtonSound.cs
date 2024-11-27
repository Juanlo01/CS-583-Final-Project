using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonSound;  // Drag your button sound here
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(PlayButtonSound);
        }
    }

    void PlayButtonSound()
    {
        // Use SoundManager to play the button sound
        if (ButtonSoundManager.instance != null && buttonSound != null)
        {
            ButtonSoundManager.instance.PlaySound(buttonSound);
        }
    }
}