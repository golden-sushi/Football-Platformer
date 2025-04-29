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
      SceneManager.LoadSceneAsync("MainMenu");
   }
   public void ScoreBoard()
   {
      SceneManager.LoadSceneAsync("ScoreBoard");
   }
}
