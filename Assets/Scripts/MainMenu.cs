using UnityEngine;
using UnityEngine.SceneManagement;

// Class to implement the main menu
public class MainMenu : MonoBehaviour
{
    // Serializing private variables to make them visible and editable in the inspector (but still private to the class)
    // rather than making them public and thus accessible and editable by other classes
    [SerializeField] private string moveSceneName = "CharacterMoveScene";
    [SerializeField] private string placementSceneName = "CharacterPlacementScene";
    [SerializeField] private string mainMenuSceneName = "MainMenuScene";

    // Function to load the CharacterMove scene
    public void CharacterMoveScene()
    {
        SceneManager.LoadScene(moveSceneName);
    }

    // Function to load the CharacterPlacement scene
        public void CharacterPlacementScene()
    {
        SceneManager.LoadScene(placementSceneName);
    }

    // Function to load the MainMenu scene
    public void MainMenuScene()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    // Function to quit the application
    public void QuitApp()
    {
        Application.Quit();
    }
}