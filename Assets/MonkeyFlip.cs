using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyFlip : MonoBehaviour
{
    void Update()
    {
        GameObject a = FindObjectOfType<Character>().gameObject;
        if (a.transform.position.x - gameObject.transform.position.x < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        else
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
}
