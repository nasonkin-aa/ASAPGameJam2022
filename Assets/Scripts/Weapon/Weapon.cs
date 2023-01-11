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
    protected float aoeSize = 1;
    [SerializeField]
    protected float tickRate;
    [SerializeField]
    public string description;
    [SerializeField]
    public Sprite icon;
    [SerializeField]
    public int level;
    [SerializeField]
    public string name;

    public abstract void LevelUp();

    public abstract void Attack();
    
}
