using UnityEngine;
using UnityEngine.SceneManagement;

// Class to implement the main menu
public class MainMenu : MonoBehaviour
{
    // Function to load the CharacterMove scene
    public void CharacterMoveScene()
    {
        SceneManager.LoadScene("CharacterMoveScene");
    }

    // Function to load the CharacterPlacement scene
        public void CharacterPlacementScene()
    {
        SceneManager.LoadScene("CharacterPlacementScene");
    }

    // Function to load the MainMenu scene
    public void MainMenuScene()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("MainMenuScene");
    }

    // Function to quit the application
    public void QuitApp()
    {
        Application.Quit();
    }
}