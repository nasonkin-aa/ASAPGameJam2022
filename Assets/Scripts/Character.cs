using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private int _speed = 2;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = transform.GetComponent<PlayerInput>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        transform.position +=
            _playerInput.Moving * Time.deltaTime * _speed;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
