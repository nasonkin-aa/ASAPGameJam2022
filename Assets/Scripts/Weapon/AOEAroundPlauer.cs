using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AOEAroundPlauer : Weapon
{
    private float timeBtwShots;
    public float startTimeBtwShots = 2;
    public int radius = 5;
    public LayerMask enemyLayerMask = 6;
    public GameObject frost;

    [SerializeField]


    public void OnDestroy()
    {
        
    }
    ~AOEAroundPlauer()
    {

    }
    public AOEAroundPlauer()
    {
        damage = 10;
        description = "������� ���� ������ ���������";
        Debug.Log(aoeSize);
    }

    private void OnDrawGizmos()
    {
        // Set the color of Gizmos to green
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, 3 * aoeSize);
    }
    public override void Attack()
    {

        //enemyColliders.ForEach(enemy => enemy.gameObject.GetComponent<Creature>().TackDamege(damage)) ;

        if (timeBtwShots <= 0)
        {        
            frost.SetActive(true);
           
            Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(transform.position, 3 * aoeSize, enemyLayerMask);
            
            foreach (var enemy in enemyColliders)
            {
                
                enemy.gameObject.GetComponent<Creature>().TackDamege(damage);
            }
            timeBtwShots = startTimeBtwShots + delayAttack;
            Invoke("DisableFrost", 0.2f);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void DisableFrost()
    {
        frost.SetActive(false);
    }
    public override void LevelUp()
    {
        switch(level)
        {
            case 0:
                description = "Damage +2";
                break;
            case 1:
                damage += 2;
                description = "Size x1.5";
                break;
            case 2:
                aoeSize *= 1.5f;
                frost.transform.localScale *= aoeSize;
                description = "Delay attack -0.5";
                break;
            case 3:
                delayAttack -= 0.5f;
                description = "Damage +2";
                break;
            default:
                damage += 2;
                description = "Damage +2";
                break;
        }
        level++;
    }
}
