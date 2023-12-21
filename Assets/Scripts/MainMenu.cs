using UnityEngine;
using GameManagers;

public class MainMenu : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the `gameManager` variable by using the public static reference in the GameManager class
        gameManager = GameManager.Instance;
    }

    public void CharacterMoveScene()
    {
        gameManager.uiManager.CharacterMoveScene();
    }
}