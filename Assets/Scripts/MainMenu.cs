using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject difficulty;

    public void PlayGame(int difficulty)
    {
        ScoreManager.difficulty = difficulty;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);      
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void TriggerDifficulty()
    {
        menu.gameObject.SetActive(false);
        difficulty.gameObject.SetActive(true);
    }
}
