using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private SceneFdaeController sceneFdaeController;
    public void PLAY()
    {
        // Load the game scene
        sceneFdaeController.LoadScene("Game");
    }
    public void QUIT()
    {
        // Quit the application
        Application.Quit();
    }
}
