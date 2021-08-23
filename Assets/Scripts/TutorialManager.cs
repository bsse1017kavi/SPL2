using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image[] images;

    public Image currentImage;

    public int currentIndex;

    public GameObject tutorialPanel;


    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
        currentImage = images[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        currentImage = images[currentIndex];
        GetComponent<Image>().sprite = currentImage.sprite;   
    }

    public void nextTutorial()
    {
        Debug.Log(currentIndex);

        if(currentIndex+1 < images.Length)
        {
            currentIndex++;
        }

        else 
        {
            Skip();
        }
    }

    public void Skip()
    {
        tutorialPanel.gameObject.SetActive(false);
    }
}
