using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStorage: MonoBehaviour 
{
    public static List<Weapon> weapons = new List<Weapon>();
    static WeaponStorage()
    {
        Weapon weapon1 = new WeaponGunPlayer(); 
        weapons.Add(weapon1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
