using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;
    public Pillar pillar;

    public void PopUp()
    {
        popUpBox.SetActive(true);
        //popUpText.SetText(text);
        animator.SetTrigger("pop");
    }

    public void close()
    {
        animator.SetTrigger("close");
        pillar.open = false;
        popUpBox.SetActive(false);
    }
}
