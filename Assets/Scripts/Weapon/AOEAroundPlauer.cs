using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAroundPlauer : Weapon
{
    private float timeBtwShots;
    public float startTimeBtwShots = 2;
    public int radius = 5;
    public LayerMask enemyLayerMask = 6;

    public AOEAroundPlauer()
    {
        damage = 10;
        description = "наносит урон вокруг персонажа";
    }

    private void OnDrawGizmos()
    {
        // Set the color of Gizmos to green
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, 3);
    }
    public override void Attack()
    {

        //enemyColliders.ForEach(enemy => enemy.gameObject.GetComponent<Creature>().TackDamege(damage)) ;

        if (timeBtwShots <= 0)
        {        
            Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, 3 * aoeSice, enemyLayerMask);
            Debug.Log("aoe " + damage);
            Debug.Log("aoe count" + enemyColliders.Length);
            foreach (var enemy in enemyColliders)
            {
                enemy.gameObject.GetComponent<Creature>().TackDamege(damage);
            }
            timeBtwShots = startTimeBtwShots + delayAttack;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public override void LevelUp()
    {
        throw new System.NotImplementedException();
    }
}
