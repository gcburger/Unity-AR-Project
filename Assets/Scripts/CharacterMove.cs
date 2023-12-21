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

    // Start is called before the first frame update
    void Start()
    {
        // Assign the gameManager variable by using the public static reference in the GameManager class
        gameManager = GameManager.Instance;
    }

    // Call the MainMenuScene function in the UIManager class
    public void MainMenuScene()
    {
        gameManager.uiManager.MainMenuScene();
    }

    // Call the TogglePause function in the GameManager class
    public void TogglePause()
    {
        gameManager.TogglePause(pauseText, pauseMenu, UI);
    }
}