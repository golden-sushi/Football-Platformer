using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
   public void RestartGame()
   {
        SceneManager.LoadSceneAsync("SampleScene");
   }
   public void MainMenu() 
   {
      SceneManager.LoadSceneAsync("Main Menu");
   }
   public void ScoreBoard()
   {
      SceneManager.LoadSceneAsync("Score Board");
   }
}
