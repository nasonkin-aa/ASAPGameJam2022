using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        Character c = col.GetComponent<Character>();
        if (c != null)
        {
            c.gameObject.GetComponent<Level>().AddExperience(400);
            Destroy(gameObject);
        }
    }
}
