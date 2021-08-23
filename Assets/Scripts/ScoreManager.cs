using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    static int coins;
    static int score;

    public static int difficulty = 1;

    public static float difficultyMultiplier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (difficulty == 0)
        {
            difficultyMultiplier = 1;
        }

        else if (difficulty == 1)
        {
            difficultyMultiplier = 1.5f;
        }

        else
        {
            difficultyMultiplier = 2;
        }

        if (instance==null)
        {
            instance = this;
        }

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            //Debug.Log(difficulty);
            coins = 0;
            score = 0;
        }
    }

    public void ChangeCoin(int coinValue)
    {
        coins += coinValue;
        text.text = "X" + coins.ToString();
    }

    public void ChangeScore(int scoreValue)
    {
        score += scoreValue;
    }

    public int GetCoins()
    {
        return coins;
    }

    public int GetScore()
    {
        return score;
    }
}
