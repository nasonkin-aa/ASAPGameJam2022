using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpRegeneration : Weapon
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
                player.HpRegenerationUp(2f);
                description = "HpRegeneration + 2";
                break;
            case 1:
                player.HpRegenerationUp(2f);
                description = "HpRegeneration + 2";
                break;
            default:
                player.HpRegenerationUp(1f);
                description = "HpRegeneration +1";
                break;
        }
    }
}
