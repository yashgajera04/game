using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManger : MonoBehaviour
{
    [SerializeField]
    private float time_to_exit;
     [SerializeField]
    private SceneFdaeController sceneFdaeController;
    

    [SerializeField]
    private GameObject Boss;
     [SerializeField]
    private GameObject Final_Boss;

    [SerializeField]
     private TMP_Text scoreText;

     [SerializeField]
    private ScoreController scoreController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Exit the game when the Escape key is pressed
            sceneFdaeController.LoadScene("Menu");
        }
        if (scoreController.Score >= 1500)
        {
            if (Boss != null)
            {
                // Deactivate the boss if it exists
                Boss.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Boss.SetActive(true);
        }
        if (scoreController.Score >= 10000)
        {
            if (Final_Boss != null)
            {
                // Deactivate the final boss if it exists
                Final_Boss.SetActive(false);
            }
        }
         if (Input.GetKeyDown(KeyCode.Y))
        {
            Final_Boss.SetActive(true);
        }

    }
    public void OnPlayerDeath()
    {
        Invoke(nameof(EndGame), time_to_exit);
    }
    private void EndGame()
    {
        // Load the main menu scene
        sceneFdaeController.LoadScene("Menu");
    }
}
