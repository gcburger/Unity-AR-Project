using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// Group under the GameManagers namespace, and to not pollute the global namespace
namespace GameManagers
{
    // Class to manage the UI in the game
    public class UIManager : MonoBehaviour
    {
        // Variables and methods are public so they can be referenced by the Game Manager

        // Serializing private variables to make them visible and editable in the inspector (but still private to the class)
        // rather than making them public and thus accessible and editable by other classes
        [SerializeField] private string moveSceneName = "CharacterMoveScene";
        [SerializeField] private string placementSceneName = "CharacterPlacementScene";
        [SerializeField] private string mainMenuSceneName = "MainMenuScene";

        // Function to toggle a scene's pause menu and UI
        public void TogglePauseMenu(bool isPaused, TMP_Text pauseText, GameObject pauseMenu, GameObject UI)
        {
            pauseMenu.SetActive(isPaused);
            UI.SetActive(!isPaused);

            if (isPaused)
            {
                pauseText.text = "Paused";
                AudioManager.Instance.PlaySoundEffect("Pause_Sfx");
            }
            else
            {
                pauseText.text = null;
                AudioManager.Instance.PlaySoundEffect("Play_Sfx");
            }
        }

        // Function to load the CharacterMove scene
        public void CharacterMoveScene()
        {
            AudioManager.Instance.PlaySoundEffect("Button_Click_Sfx");
            SceneManager.LoadScene(moveSceneName);
        }

        // Function to load the CharacterPlacement scene
            public void CharacterPlacementScene()
        {
            AudioManager.Instance.PlaySoundEffect("Button_Click_Sfx");
            SceneManager.LoadScene(placementSceneName);
        }

        // Function to load the MainMenu scene
        public void MainMenuScene()
        {
            AudioManager.Instance.PlaySoundEffect("Button_Click_Sfx");
            SceneManager.LoadScene(mainMenuSceneName);
        }

        // Function to quit the application
        public void QuitApp()
        {
            AudioManager.Instance.PlaySoundEffect("Button_Click_Sfx");
            Application.Quit();
        }
    }
}