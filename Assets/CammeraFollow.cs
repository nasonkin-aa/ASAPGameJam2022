using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CammeraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    void Update()
    {
        var position = _player.transform.position;
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }
}
