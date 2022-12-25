using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolobokKotitca : MonoBehaviour
{
    private void Update()
    {
        GameObject a = FindObjectOfType<Character>().gameObject;
        if (a.transform.position.x - gameObject.transform.position.x < 0)
            transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
        else
            transform.Rotate(new Vector3(0, 0, -90) * Time.deltaTime);
    }
}
