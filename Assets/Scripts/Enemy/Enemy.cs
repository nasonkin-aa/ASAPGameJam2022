using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature
{
    [SerializeField]
    protected int Damage;

    protected GameObject player;
    Vector3 positionPlayer;
    protected virtual void Move()
    {
        transform.position += Vector3.Normalize(positionPlayer - transform.position) * _speed * Time.deltaTime;
    }
    private void Awake()
    {
        player = FindObjectOfType<Character>().gameObject;
    }
    public virtual void Update()
    {
        positionPlayer = player.transform.position;
        Move();
    }
}
