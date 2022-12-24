using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUpPassive : Weapon
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
                player.HpBoost(20);
                description = "HP +20";
                break;
            case 1:
                player.HpBoost(20);
                description = "HP +10";
                break;
            default:
                player.HpBoost(10);
                description = "HP +10";
                break;
        }
    }
}
