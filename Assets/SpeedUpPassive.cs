using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpPassive : Weapon
{
    [SerializeField]
    private Character player;

    public void Awake()
    {
        player = GetComponent<Character>();
    }
    public override void Attack()
    {
        return;
    }

    public override void LevelUp()
    {
        LevelWeaponUpdate();
        level++;

    }
    private void LevelWeaponUpdate()
    {
        switch (level)
        {
            case 0:
                player.SpeedBoost(1);
                description = "Speed +1";
                break;
            case 1:
                player.SpeedBoost(1);
                description = "Speed +1";
                break;
            default:
                player.SpeedBoost(0.5f); 
                description = "Speed + 0.5";
                break;
        }
    }
}
