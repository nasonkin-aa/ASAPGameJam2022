using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int level = 1;
    private int experience = 0;

    [SerializeField] private ExpBar _expBar;
    [SerializeField] private UpgradePanel _upgradePanel;
    int TO_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        _expBar.UpdateExpSlider(experience,TO_LEVEL_UP);
        _expBar.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        LevelUp();
        _expBar.UpdateExpSlider(experience, TO_LEVEL_UP);
    }

    private void LevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            _upgradePanel.OpenPanel();
            experience -= TO_LEVEL_UP;
            level += 1;
            _expBar.SetLevelText(level);
        }
    }
}
