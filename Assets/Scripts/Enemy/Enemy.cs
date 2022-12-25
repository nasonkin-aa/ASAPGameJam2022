using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature
{
    [SerializeField]
    protected int Damage;

    [SerializeField] private GameObject drop;

    [SerializeField] public int expeienceReward = 400;

    protected GameObject player;
    Vector3 positionPlayer;
    Rigidbody2D rigidbody2D;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Character>().gameObject;

    }
    protected virtual void Move()
    {
        rigidbody2D.position +=(Vector2) Vector3.Normalize(positionPlayer - transform.position) * _speed * Time.deltaTime;
    }
   
    public virtual void Update()
    {
        positionPlayer = player.transform.position;
        Move();
    }

    public override void Die(GameObject creature)
    {
        Transform t = Instantiate(drop).transform;
        t.position = transform.position;
        base.Die(creature);
    }
}
