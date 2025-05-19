using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManger : MonoBehaviour
{
     public static GameManger instance { set; get; }
     private Player player;
     private bool isGameStarted = false;

     // UI AND UI FIELDS
     public Text scoreText, coinscoreText, modifiersText;
     private float score, coinscore = 0f;
     private float modifiersScore = 1.0f;
     private float coinprice = 5.0f;

     private void Awake()
     {
          instance = this;
          player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
          UpdateScores();
     }
     private void Update()
     {
          if (Input.GetKeyDown(KeyCode.Space))
          {
               isGameStarted = true;
               player.StartGame();
               //Debug.Log("Game Started");
          }
          if (isGameStarted)
          {
               score += Time.deltaTime * modifiersScore;
               scoreText.text = score.ToString("0.00 scoreText.text = score.ToString();");
          }
     }
     public void UpdateScores()
     {
          scoreText.text = score.ToString();
          coinscoreText.text = coinscore.ToString("0");
          modifiersText.text = modifiersScore.ToString("x0.0");
     }
     public void UpdatemodifiersScore(float value)
     {
          modifiersScore = value + 1.0f;
          UpdateScores();
     }
     public void coinscoreUpdate()
     {
          coinscore += 1 * coinprice;
          UpdateScores();
     }
     public void stopscore()
     {
          isGameStarted = false;
     }
   
   public void reastartGame()
   {
        SceneManager.LoadScene(1);
   }
}
