using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float delayAttack;
    [SerializeField]
    protected int levelGun = 0;
    [SerializeField]
    protected int projectileNumber;
    [SerializeField]
    protected float projectileSpeed;
    [SerializeField]
    protected float aoeSice;
    [SerializeField]
    protected float tickRate;
    [SerializeField]
    public string description;
    [SerializeField]
    public Sprite icon;
    [SerializeField]
    protected int level;
    [SerializeField]
    public string name;

    public abstract void LevelUp();

    public abstract void Attack();
    
}
