using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject drop;
    private void OnDestroy()
    {
        Transform t = Instantiate(drop).transform;
        t.position = transform.position;
    }
}
