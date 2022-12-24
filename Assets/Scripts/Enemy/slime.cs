using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : Enemy
{
    
    protected override void Move()
    {
        base.Move();
    }
    public override void Update()
    {
        base.Update();
        Move();
    }
    protected override void TackDamege()
    {
        throw new System.NotImplementedException();
    }
    protected override void Attac()
    {
        throw new System.NotImplementedException();
    }


    
}
