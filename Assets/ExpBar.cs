using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text levelText;
    

    public void UpdateExpSlider(int cur, int target)
    {
        slider.maxValue = target;
        slider.value = cur;
    }

    public void SetLevelText(int level)
    {
        levelText.text = "Level: " + level.ToString();
    }
}
