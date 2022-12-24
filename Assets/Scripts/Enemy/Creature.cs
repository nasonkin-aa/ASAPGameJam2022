using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField]
    protected float _hp;
    [SerializeField]
    protected float _speed;

    public virtual void TackDamege(int damage)
    {
        Debug.Log(damage);
        _hp -= damage;
        if (_hp <= 0)
        {
            //FindObjectOfType<Character>().gameObject.GetComponent<Level>()
            //    .AddExperience(gameObject.GetComponent<Enemy>().expeienceReward);
            Die(transform.gameObject);
        }
    }
    protected abstract void Attac(int damge);

    public virtual void Die(GameObject creature)
    {
        
        Destroy(creature);
    }
}
