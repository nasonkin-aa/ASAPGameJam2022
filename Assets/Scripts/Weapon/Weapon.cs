using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float delayAttack;
    
    public abstract void Attack();
    
}
