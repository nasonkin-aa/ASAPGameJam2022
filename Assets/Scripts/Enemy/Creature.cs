using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField]
    protected float Hp;
    [SerializeField]
    protected float Speed;

    protected abstract void TackDamege();
    protected abstract void Attac();
}
