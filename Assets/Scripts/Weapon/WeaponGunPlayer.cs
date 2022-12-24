using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class WeaponGunPlayer : Weapon
{
    public GameObject bullet;
    public LayerMask enemyLayerMask = 6;
    private float timeBtwShots;
    public float startTimeBtwShots = 2;

    public WeaponGunPlayer()
    {
        damage = 10;
        projectileSpeed = 10;
        description = " кидает пирожок в ближайшего врага";
    }
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }
    
    Vector2 FindClosestEnemy(Vector3 position)
    {
        GameObject closeEnemy = null;
        Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(position, 9, enemyLayerMask);
        if (enemyColliders.Length != 0)
        {
            float distance = Mathf.Infinity;
            foreach(Collider2D enemyCol in enemyColliders)
            {
                if (enemyCol.name == "Bullet(Clone)")
                    continue;
            
                Vector2 diff = enemyCol.gameObject.transform.position - position;
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
            Vector2 close = FindClosestEnemy(transform.position);
            close.x -= transform.position.x;
            close.y -= transform.position.y;
            Vector2 ShotingDiraction =
                new Vector2(close.x, close.y);
            
            ShotingDiraction.Normalize();
            curBullet.gameObject.GetComponent<Rigidbody2D>().velocity = ShotingDiraction * projectileSpeed;
            curBullet.gameObject.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(ShotingDiraction.y,ShotingDiraction.x) * Mathf.Rad2Deg);
            timeBtwShots = startTimeBtwShots + delayAttack;
                
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

    public override void LevelUp()
    {
        levelGun++;
        LevelWeaponUpdate();
    }
    private void LevelWeaponUpdate() 
    {
        switch(levelGun)
        {
            case 1:
                damage += 5;
                description = "delay attack -1";
                break;
            case 2:
                delayAttack -= 1;
                description = "projectile speeds 1.5";
                break;
            case 3:
                projectileSpeed *= 1.5f;
                description = "damage +5";
                break;
            default:
                damage += 5;
                description = "damage +5";
                break;
        } 
    }

   
}
