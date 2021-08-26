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

        if (difficulty == 0)
        {
            ScoreManager.difficultyMultiplier = 1;
        }

        else if (difficulty == 1)
        {
            ScoreManager.difficultyMultiplier = 1.5f;
        }

        else
        {
            ScoreManager.difficultyMultiplier = 2;
        }

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
