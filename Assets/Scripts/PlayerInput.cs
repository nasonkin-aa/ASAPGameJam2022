using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _move = new Vector3();
    public Vector3 Moving
    {
        get => _move;
    }

    // Update is called once per frame
    void Update()
    {
        _move = Vector3.zero;
        _move.x = Input.GetAxis("Horizontal");
        _move.y = Input.GetAxis("Vertical");
    }
}
