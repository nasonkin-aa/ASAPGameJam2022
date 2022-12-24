using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class WeaponGunPlayer : Weapon
{
    public float speed;
    
    public GameObject bullet;
    public LayerMask enemyLayerMask;
    private float timeBtwShots;
    public float startTimeBtwShots;
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }
    
    Vector2 FindClosestEnemy()
    {
        GameObject closeEnemy = null;
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, 9, enemyLayerMask);
        if (enemyColliders.Length != 0)
        {
            float distance = Mathf.Infinity;
            foreach(Collider2D enemyCol in enemyColliders)
            {
                if (enemyCol.name == "Bullet(Clone)")
                    continue;
            
                Vector2 diff = enemyCol.gameObject.transform.position - transform.position;
                float curDistance = diff.magnitude;
                if (curDistance < distance)
                {
                    distance = curDistance;
                    closeEnemy = enemyCol.gameObject;
                }
            }
            return closeEnemy.transform.position;
            
        }
        return new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)).normalized;
    }

    private void gunAttack()
    {
        if (timeBtwShots <= 0)
        {
            GameObject curBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            curBullet.GetComponent<Bullet>().damage = damage;
            Vector2 close = FindClosestEnemy();
            close.x -= transform.position.x;
            close.y -= transform.position.y;
            //Debug.Log(close);
            Vector2 ShotingDiraction =
                new Vector2(close.x, close.y);
            
            ShotingDiraction.Normalize();
            curBullet.gameObject.GetComponent<Rigidbody2D>().velocity = ShotingDiraction * speed;
            curBullet.gameObject.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(ShotingDiraction.y,ShotingDiraction.x) * Mathf.Rad2Deg);
            timeBtwShots = startTimeBtwShots;
                
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public override void Attack()
    {
        gunAttack();
    }
}
