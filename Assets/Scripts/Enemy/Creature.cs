using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField]
    protected float Hp;
    [SerializeField]
    protected float Speed;

    public virtual void TackDamege(int damage)
    {
        Debug.Log(damage);
        Hp -= damage;
        if (Hp <= 0)
        {
            Die(transform.gameObject);
        }
    }
    protected abstract void Attac(int damge);

    public virtual void Die( GameObject creature)
    {
        Destroy(creature);
    }
}
