using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{

    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        int scoreValue = (int)(ScoreManager.instance.GetScore() * ScoreManager.difficultyMultiplier);

        score.text = "" + scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
