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

    //public MagicLauncher magicLauncher;

    // Start is called before the first frame update
    void Start()
    {
        //magicLauncher = player.GetComponent<MagicLauncher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.transform.position.x - player.transform.position.x) <= 2 && Mathf.Abs(this.transform.position.y - player.transform.position.y) <= 2)
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

    public void Buy(int num)
    {
        if(num==1 && scoreManager.GetCoins()>=5)
        {
            scoreManager.ChangeCoin(-5);
            player.IncreaseFocus(50);
        }

        if (num == 2 && scoreManager.GetCoins() >= 10)
        {
            scoreManager.ChangeCoin(-10);
            MagicLauncher.fireAmount += 5;
        }
    }
}
