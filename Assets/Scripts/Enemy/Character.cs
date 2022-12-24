using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Creature
{
    bool IsSaveCharacter;
    private PlayerInput _playerInput;
    Rigidbody2D rigidbody2D;
    public List<Weapon> _weapons = new List<Weapon>();

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = transform.GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _weapons.Add(transform.GetComponent<WeaponGunPlayer>() );
    }

    void Update()
    {
        rigidbody2D.position +=
          (Vector2) _playerInput.Moving * Time.deltaTime * _speed;
        _weapons.ForEach(e=>e.Attack());
    }
    protected override void Attac(int damage)
    {
        throw new System.NotImplementedException();
    }

    public override void TackDamege(int damage)
    {
        if (!IsSaveCharacter)
        {
            StartCoroutine(SaveTime());
            base.TackDamege(damage);
        }
    }
    IEnumerator SaveTime()
    {
        IsSaveCharacter = true;
        yield return new WaitForSeconds(2f);
        IsSaveCharacter = false;
    }

    
    

}
