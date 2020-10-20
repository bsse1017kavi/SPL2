using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FocusBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxFocus(int focus)
    {
        slider.maxValue = focus;
        slider.value = 0;
    }

    public void setFocus(int focus)
    {
        slider.value = focus;
    }
}
