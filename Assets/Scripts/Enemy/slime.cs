using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : Enemy
{

  /*  protected override void TackDamege(int damage)
    {
   
    }*/
    protected override void Attac(int damage)
    {
        player.GetComponent<Character>().TackDamege(damage);
    }

   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Attac(Damage);
        }
    }

}
