using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : Chains
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Debug.Log("111111" + damage);
            collision.gameObject.GetComponent<Enemy>().TackDamege(damage);
        }

    }
    public override void Attack()
    {
        return;
    }

    public override void LevelUp()
    {
        switch (level)
        {
            case 0:
                description = "damage +2";
                break;
            case 1:
                damage += 2;
                description = "aoe size x1.5";
                break;
            case 2:
                aoeSice *= 1.5f;
                description = "delay attack -0.5";
                break;
            case 3:
                delayAttack -= 0.5f;
                description = "damage +2";
                break;
            default:
                damage += 2;
                description = "damage +2";
                break;
        }
        level++;
    }
}
