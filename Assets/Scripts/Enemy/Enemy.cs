using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Creature
{
    protected float Damage;

    GameObject player;
    Vector3 positionPlayer;
    protected virtual void Move()
    {
        transform.position += Vector3.Normalize(positionPlayer - transform.position) * Speed * Time.deltaTime;
    }
    private void Awake()
    {
        player = FindObjectOfType<Character>().gameObject;
        Debug.Log(player.name);
    }
    public virtual void Update()
    {
        positionPlayer = player.transform.position;
        Move();
    }
}
