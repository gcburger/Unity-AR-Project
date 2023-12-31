using UnityEngine;
using TMPro;

// Group under the GameManagers namespace, and to not pollute the global namespace
namespace GameManagers
{
    // Class to track and control the game instance
    public class GameManager : MonoBehaviour
    {
        // Serializing private variables to make them visible and editable in the inspector (but still private to the class)
        // rather than making them public and thus accessible and editable by other classes

        // Static (won't change) reference to the singleton GameManager instance
        public static GameManager Instance;
        private bool isPaused = false;

        // Variable to store the UIManager component
        public UIManager uiManager;

        private void Awake()
        {
            // Singleton design pattern to ensure only one instance of the Game Manager exists

            // If the singleton instance has not been set, set it to this instance
            if (Instance == null)
            {
                // Keep the gameObject this component is attached to, across different scenes
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            // Don't destroy the Game Manager instance when switching back to the MainMenu scene
            // Keep the single instance alive throughout the running time of the app
            /*else if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }*/
        }

        // Function to pause the game and toggle a scene's pause menu and UI
        public void TogglePause(TMP_Text sourcePauseText, GameObject sourcePauseMenu, GameObject sourceUI)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

            // Toggle the pause menu and UI using the UIManager component
            uiManager.TogglePauseMenu(isPaused, sourcePauseText, sourcePauseMenu, sourceUI);
        }
    }
}