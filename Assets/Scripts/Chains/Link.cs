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
   
}
