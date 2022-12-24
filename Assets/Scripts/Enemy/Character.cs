using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Creature
{
    bool IsSaveCharacter;
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
