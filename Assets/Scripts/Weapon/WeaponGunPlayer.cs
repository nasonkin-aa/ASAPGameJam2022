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

    float pauseBtwShots = 0.5f;
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
            for(int i = 0; i < projectileNumber; i++)
            {
                Invoke("CreatBullet",i * pauseBtwShots);

            }

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void CreatBullet()
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
        curBullet.gameObject.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(ShotingDiraction.y, ShotingDiraction.x) * Mathf.Rad2Deg);
        timeBtwShots = startTimeBtwShots + delayAttack;
    }

    public override void Attack()
    {
        gunAttack();
    }

    public override void LevelUp()
    {
        LevelWeaponUpdate();
        level++;
        
    }
    private void LevelWeaponUpdate() 
    {
        switch(level)
        {
            case 0:
                description = "Projectile + 1";
                projectileNumber++;
                break;
            case 1:
                projectileNumber++;
                description = "Projectile + 1";
                break;
            case 2:
                projectileNumber++;
                description = "Projectile speed * 1.5";
                break;
            case 3:
                projectileSpeed *= 1.5f;
                description = "delay Attack -0.5";
                break;
            case 4:
                delayAttack -= 0.5f;
                pauseBtwShots = 0.3f;
                description = "Projectile + 1";
                break;
            default:
                projectileNumber++;
                description = "Projectile + 1";
                break;
        } 
    }

   
}
