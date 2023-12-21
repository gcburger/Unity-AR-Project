using UnityEngine;
using GameManagers;
using TMPro;

public class CharacterMove : MonoBehaviour
{
    // Serializing private variables to make them visible and editable in the inspector (but still private to the class)
    // rather than making them public and thus accessible and editable by other classes
    private GameManager gameManager;
    [SerializeField] private TMP_Text pauseText;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject buttonAudioOn;
    [SerializeField] private GameObject buttonAudioOff;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the gameManager variable by using the public static reference in the GameManager class
        gameManager = GameManager.Instance;

        // On scene load, dislay the correct audio button based on whether the audio is muted or not
        if (!AudioManager.Instance.audioSource.mute)
        {
            buttonAudioOn.SetActive(true);
            buttonAudioOff.SetActive(false);
        }
        else if (AudioManager.Instance.audioSource.mute)
        {
            buttonAudioOff.SetActive(true);
            buttonAudioOn.SetActive(false);
        }
    }

    // Call the MainMenuScene function in the UIManager class
    public void MainMenuScene()
    {
        gameManager.uiManager.MainMenuScene();
    }

    // Call the ToggleAudio function in the AudioManager class
    public void ToggleAudio()
    {
        AudioManager.Instance.ToggleAudio();

        // When the button is clicked, dislay the correct audio button based on whether the audio is muted or not
        if (!AudioManager.Instance.audioSource.mute)
        {
            buttonAudioOn.SetActive(true);
            AudioManager.Instance.PlaySoundEffect("Play_Sfx");
            buttonAudioOff.SetActive(false);
        }
        else if (AudioManager.Instance.audioSource.mute)
        {
            buttonAudioOff.SetActive(true);
            buttonAudioOn.SetActive(false);
        }
    }

    // Call the TogglePause function in the GameManager class
    public void TogglePause()
    {
        gameManager.TogglePause(pauseText, pauseMenu, UI);
    }
}