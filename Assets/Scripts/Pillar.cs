using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pillar : MonoBehaviour
{
    public PopUpSystem popUpSystem;
    public bool playerWithinRange = false;
    public Player player;
    public Button openShop;
    public bool open = false;

    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.transform.position.x - player.transform.position.x) <= 2)
        {
            playerWithinRange = true;
            openShop.gameObject.SetActive(true);
        }

        else
        {
            playerWithinRange = false;
            openShop.gameObject.SetActive(false);
        }

        if(playerWithinRange && open)
        {
            popUpSystem.PopUp();
        }

    }

    public void Open()
    {
        this.open = true;
    }

    public void Buy()
    {
        if(scoreManager.GetScore()>=5)
        {
            scoreManager.ChangeScore(-5);
            player.IncreaseFocus(50);
        }
    }
}
